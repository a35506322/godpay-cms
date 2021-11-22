using GodPay_CMS.Controllers.ViewModels;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Interfaces
{
    /// <summary>
    /// 登入伺服器
    /// </summary>
    public interface ISigninService
    {
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="signinReq"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> SigninUser(SigninViewModel signinViewModel);
    }
}
