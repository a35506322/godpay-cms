using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.ViewModels;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Interfaces
{
    /// <summary>
    /// 業務管理伺服器
    /// </summary>
    public interface IBusinessManagementService
    {
        /// <summary>
        /// 取得使用者
        /// </summary>
        /// <param name="role">角色</param>
        /// <returns></returns>
        Task<ResponseViewModel> GetUsersByRole(RoleEnum role);
    }
}
