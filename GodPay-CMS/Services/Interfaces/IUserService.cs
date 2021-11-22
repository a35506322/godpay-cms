using GodPay_CMS.Controllers.ViewModels;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Interfaces
{
    /// <summary>
    /// 使用者伺服器
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 取得使用者
        /// </summary>
        /// <param name="userId">帳號</param>
        /// <returns></returns>
        public Task<ResponseViewModel> GetUserByUserId(string userId);
        /// <summary>
        /// 更新使用者
        /// </summary>
        /// <param name="editUserViewModel"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> UpdateUser(EditUserViewModel editUserViewModel);
    }
}
