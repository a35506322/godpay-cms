using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.DTO;
using GodPay_CMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Implements
{
    public class AuthorityService : IAuthorityService
    {
        private readonly IRepostioryWrapper _repostioryWrapper;
        private readonly IMapper _mapper;
        public AuthorityService(IRepostioryWrapper repostioryWrapper, IMapper mapper)
        {
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
    }
}
