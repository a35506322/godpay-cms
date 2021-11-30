using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.DTO;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Interfaces
{
    /// <summary>
    /// 業務管理伺服器
    /// </summary>
    public interface IBusinessService
    {
        /// <summary>
        /// 取得業務們
        /// </summary>
        /// <returns></returns>
        Task<ResponseViewModel> GetBusinessmens();
        /// <summary>
        /// 取得業務詳細資料
        /// </summary>
        /// <param name="id">帳號</param>
        /// <returns></returns>
        Task<ResponseViewModel> GetBusinessmenDeatil(int id);
        /// <summary>
        /// 新增業務及詳細資料
        /// </summary>
        /// <param name="postUserAndInsiderViewModel"></param>
        /// <returns></returns>
        Task<ResponseViewModel> PostBusinessmanAndInsider(PostUserAndInsiderViewModel postUserAndInsiderViewModel);
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
        /// <summary>
        /// 取得篩選業務們詳細資料
        /// </summary>
        /// <param name="userParams">Query</param>
        /// <returns></returns>
        Task<ResponseViewModel> GetBusinessmensFilter(UserParams userParams);
    }
}
