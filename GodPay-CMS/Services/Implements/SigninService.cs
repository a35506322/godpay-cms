using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Common.Helpers;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.DTO;
using GodPay_CMS.Services.Interfaces;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Implements
{
    public class SigninService : ISigninService
    {
        private readonly IRepostioryWrapper _repostioryWrapper;
        private readonly IMapper _mapper;

        public SigninService(IRepostioryWrapper repostioryWrapper, IMapper mapper)
        {
            _repostioryWrapper = repostioryWrapper;
            _mapper = mapper;
        }

        public async Task<ResponseViewModel> SigninUser(SigninViewModel signinViewModel)
        {
            var userReq = _mapper.Map<User>(signinViewModel);

            var user = await _repostioryWrapper.userRepository.GetByUserIdAndUserKey(userReq);

            var userRsp = _mapper.Map<UserRsp>(user);

            if (userRsp == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.LoginFail, RtnMessage = ReturnCodeEnum.LoginFail.GetEnumDescription(), RtnData = "帳號密碼錯誤" };

            if(userRsp.Status==AccountStatusEnum.Deactivate)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.LoginFail, RtnMessage = ReturnCodeEnum.LoginFail.GetEnumDescription(), RtnData = "帳號停用中，請聯絡管理員" };

            await _repostioryWrapper.userRepository.UpdateLoginTime(userReq);

            return new ResponseViewModel() { RtnData = userRsp };
        }
    }
}
