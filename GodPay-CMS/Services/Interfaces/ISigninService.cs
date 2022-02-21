using GodPay_CMS.Services.DTO.Request;
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
        /// <param name="postSigninReq">postSigninReq</param>
        /// <returns></returns>
        public Task<ResponseViewModel> SigninUser(PostSigninReq postSigninReq);
    }
}
