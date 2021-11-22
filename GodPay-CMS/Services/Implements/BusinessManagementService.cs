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
    public class BusinessManagementService : IBusinessManagementService
    {
        private readonly IRepostioryWrapper _repostioryWrapper;
        private readonly IMapper _mapper;
        public BusinessManagementService(IRepostioryWrapper repostioryWrapper, IMapper mapper)
        {
            _repostioryWrapper = repostioryWrapper;
            _mapper = mapper;
        }
        public async Task<ResponseViewModel> GetUsersByRole(RoleEnum role)
        {
            var users = await _repostioryWrapper.userRepository.GetByRole(role);

            var userRsp = _mapper.Map<IEnumerable<UserFilterRsp>>(users);

            if (userRsp == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = "查無使用者資料" };

            return new ResponseViewModel() { RtnData = userRsp };
        }
    }
}
