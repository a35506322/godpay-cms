using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.DTO;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Implements
{
    public class AuthorityService : IAuthorityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepostioryWrapper _repostioryWrapper;
        private readonly IMapper _mapper;
        public AuthorityService(IRepostioryWrapper repostioryWrapper, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _repostioryWrapper = repostioryWrapper;
            _mapper = mapper;
        }

        public async Task<ResponseViewModel> GetListOfFunctions()
        {
            var funcCalss = await _repostioryWrapper.funcClassRepository.GetByFuncClassAndFunc();

            if (funcCalss == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.GetFail, RtnData = "取得功能資料失敗" };

            var functionListViewModel = _mapper.Map<IEnumerable<FuncClassFilterRsp>>(funcCalss);

            return new ResponseViewModel() { RtnData = functionListViewModel };
        }

        public async Task<ResponseViewModel> GetListOfFunctionsFilter(FunctionParams functionParams)
        {
            var getFuncFilterReq = _mapper.Map<GetFuncFilterReq>(functionParams);
            getFuncFilterReq.Role = (int)(RoleEnum)Enum.Parse(typeof(RoleEnum), _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Role).Value);
            getFuncFilterReq.FuncFlag = int.Parse(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == "FuncFlag").Value);

            var funcCalss = await _repostioryWrapper.funcClassRepository.GetByFuncClassAndFuncFilter(getFuncFilterReq);

            if (funcCalss == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.GetFail, RtnData = "取得功能資料失敗" };

            var functionListViewModel = _mapper.Map<IEnumerable<FuncClassFilterRsp>>(funcCalss);

            return new ResponseViewModel() { RtnData = functionListViewModel };
        }
    }
}
