using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.DTO;
using GodPay_CMS.Services.DTO.Request;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Interfaces
{
    /// <summary>
    /// 業務管理伺服器
    /// </summary>
    public interface IManagerService
    {
        /// <summary>
        /// 取得業務們
        /// </summary>
        /// <returns></returns>
        public Task<ResponseViewModel> GetManagerAll();

        /// <summary>
        /// 取得業務詳細資料
        /// </summary>
        /// <param name="id">帳號</param>
        /// <returns></returns>
        public Task<ResponseViewModel> GetManagerDeatil(int id);

        /// <summary>
        /// 新增業務及詳細資料
        /// </summary>
        /// <param name="postUserAndInsiderReq">postUserAndInsiderReq</param>
        /// <returns></returns>
        public Task<ResponseViewModel> PostManagerAndInsider(PostUserAndInsiderReq postUserAndInsiderReq);

        /// <summary>
        /// 更新業務及詳細資料
        /// </summary>
        /// <param name="putUserAndInsiderReq">putUserAndInsiderReq</param>
        /// <returns></returns>
        public Task<ResponseViewModel> UpdateManagerAndInsider(PutUserAndInsiderReq putUserAndInsiderReq);

        /// <summary>
        /// 取得業務及詳細資料
        /// </summary>
        /// <param name="userId">帳號</param>
        /// <returns></returns>
        public Task<ResponseViewModel> GetManagerAndInsiderByUserId(string userId);

        /// <summary>
        /// 取得篩選業務們詳細資料
        /// </summary>
        /// <param name="userParams">Query</param>
        /// <returns></returns>
        public Task<ResponseViewModel> GetManagerFilter(UserParams userParams);

        /// <summary>
        /// 取得單筆業務權限
        /// </summary>
        /// <returns></returns>
        public Task<ResponseViewModel> GetManagerAuthority(string userId);

        /// <summary>
        /// 修改業務權限
        /// </summary>
        /// <param name="putUserAuthorityReq">putUserAuthorityReq</param>
        /// <returns></returns>
        public Task<ResponseViewModel> UpdateManagerAuthority(PutUserAuthorityReq putUserAuthorityReq);
    }
}
