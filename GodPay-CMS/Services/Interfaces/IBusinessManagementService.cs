using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.DTO;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Interfaces
{
    /// <summary>
    /// 業務管理伺服器
    /// </summary>
    public interface IBusinessManagementService
    {
        /// <summary>
        /// 取得業務們
        /// </summary>
        /// <param name="role">角色</param>
        /// <returns></returns>
        Task<ResponseViewModel> GetBusinessmens();
        /// <summary>
        /// 取得業務詳細資料
        /// </summary>
        /// <param name="id">帳號</param>
        /// <returns></returns>
        Task<ResponseViewModel> GetBusinessmenDeatil(string id);
        /// <summary>
        /// 新增業務及詳細資料
        /// </summary>
        /// <param name="postUserAndInsiderReq"></param>
        /// <returns></returns>
        Task<ResponseViewModel> PostBusinessmanAndInsider(PostUserAndInsiderViewModel postUserAndInsiderReq);
        /// <summary>
        /// 更新業務及詳細資料
        /// </summary>
        /// <param name="postUserAndInsiderReq"></param>
        /// <returns></returns>
        Task<ResponseViewModel> UpdateBusinessmanAndInsider(UpdateUserAndInsiderViewModel updateUserAndInsiderViewModal);
        /// <summary>
        /// 取得業務及詳細資料
        /// </summary>
        /// <param name="userId">帳號</param>
        /// <returns></returns>
        public Task<ResponseViewModel> GetUserAndInsiderByUserId(string userId);
    }
}
