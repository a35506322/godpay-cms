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

            var functionListViewModel = _mapper.Map<IEnumerable<AuthorityFuncClassRsp>>(funcCalss);

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

            var functionListViewModel = _mapper.Map<IEnumerable<AuthorityFuncClassRsp>>(funcCalss);

            return new ResponseViewModel() { RtnData = functionListViewModel };
        }

        public async Task<ResponseViewModel> UpdateRoleMaxAuthority(IEnumerable<UpdateFuncClassViewModel> updateFuncClassViewModels)
        {
            if (updateFuncClassViewModels.Count() == 0)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.AuthenticationLogicFail, RtnData = "修改角色資訊個數不能為0" };

            // 取得原資料與新資料做差異對比
            var funcCalsses = await _repostioryWrapper.funcClassRepository.GetByFuncClassAndFunc();
            List<UpdateRoleAuthorityReq> oldAuthority = new List<UpdateRoleAuthorityReq>();
            foreach (var funClass in funcCalsses)
            {
                oldAuthority.AddRange(_mapper.Map<IEnumerable<UpdateRoleAuthorityReq>>(funClass.Funcs));
            }

            List<UpdateRoleAuthorityReq> newAuthority = new List<UpdateRoleAuthorityReq>();
            foreach (var funClass in updateFuncClassViewModels)
            {
                newAuthority.AddRange(_mapper.Map<IEnumerable<UpdateRoleAuthorityReq>>(funClass.UpdateFuncViewModel));
            }
            var updateRoleAuthorityReqs = newAuthority.Where(c => !oldAuthority.Any(n => n.Fid == c.Fid && n.FuncCode == c.FuncCode && n.RoleFlag == c.RoleFlag));

            var result =  await _repostioryWrapper.funcRepository.BatchUpdateRoleFlag(updateRoleAuthorityReqs);
            if (result)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.Ok, RtnData = "修改角色最大權限成功" };
            else
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnData = "修改角色最大權限失敗" };
        }
        public async Task<ResponseViewModel> GetListOfFuncClass()
        {
            var allFunc = await _repostioryWrapper.funcClassRepository.GetAll();
            if (allFunc == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.GetFail, RtnData = "取得資料失敗" };
            var allFuncRsp = _mapper.Map<IEnumerable<FuncClassRsp>>(allFunc);
            return new ResponseViewModel() { RtnData = allFuncRsp };
        }
    }
}
