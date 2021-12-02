using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.ViewModels;
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
            var signinReq = _mapper.Map<SigninReq>(signinViewModel);

            var user = await _repostioryWrapper.userRepository.GetByUserIdAndUserKey(signinReq);

            var userRsp = _mapper.Map<UserRsp>(user);

            if (userRsp == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.LoginFail, RtnMessage = "登入失敗", RtnData = "帳號密碼錯誤" };

            await _repostioryWrapper.userRepository.UpdateLoginTime(signinReq);

            return new ResponseViewModel() { RtnData = userRsp };
        }
    }
}
