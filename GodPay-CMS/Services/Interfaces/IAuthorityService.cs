using GodPay_CMS.Controllers.ViewModels;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Interfaces
{
    /// <summary>
    /// 權限伺服器
    /// </summary>
    public interface IAuthorityService
    {
        /// <summary>
        /// 功能列表(角色塞選)
        /// </summary>
        /// <returns></returns>
        public Task<ResponseViewModel> GetListOfFunctions();
    }
}
