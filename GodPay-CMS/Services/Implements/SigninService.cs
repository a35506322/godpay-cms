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

        public SigninService(IRepostioryWrapper repostioryWrapper)
        {
            _repostioryWrapper = repostioryWrapper;
        }

        public async Task<ResponseViewModel> SigninUser(SigninReq signinReq)
        {
            var result = await _repostioryWrapper.userRepository.GetByUserIdAndUserKey(signinReq);

            if (result == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.LoginFail, RtnMessage = "登入失敗", RtnData="帳號密碼錯誤" };

            return new ResponseViewModel() { RtnData = result };
        }


    }
}
