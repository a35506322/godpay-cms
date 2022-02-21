using GodPay_CMS.Controllers.ViewModels;
using System.Threading.Tasks;
using GodPay_CMS.Services.DTO.Request;

namespace GodPay_CMS.Services.Interfaces
{
    public interface IStoreService
    {
        /// <summary>
        /// 取得特店們
        /// </summary>
        /// <param name="role">角色</param>
        /// <returns></returns>
        public Task<ResponseViewModel> GetStores();

        /// <summary>
        /// 取得特店詳細資料
        /// </summary>
        /// <param name="sid">PK</param>
        /// <returns></returns>
        public Task<ResponseViewModel> GetStoreDeatil(int uid);

        /// <summary>
        /// 新增特店及詳細資料
        /// </summary>
        /// <param name="postUserAndStoreReq"></param>
        /// <returns></returns>
        Task<ResponseViewModel> PostUserAndStore(PostUserAndStoreReq postUserAndStoreReq);

        /// <summary>
        /// 取得特店及詳細資料
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> GetUserAndStoreByUserId(string userId);

        /// <summary>
        /// 更新特店及詳細資料
        /// </summary>
        /// <param name="putUserAndStoreReq">putUserAndStoreReq</param>
        /// <returns></returns>
        public Task<ResponseViewModel> UpateUserAndStore(PutUserAndStoreReq putUserAndStoreReq);

        /// <summary>
        /// 更新特店
        /// </summary>
        /// <param name="putStoreReq">putStoreReq</param>
        /// <returns></returns>
        public Task<ResponseViewModel> UpateStore(PutStoreReq putStoreReq);

        /// <summary>
        /// 取得特店角色權限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> GetStoreAuthority(string userId);

        /// <summary>
        /// 修改特店角色權限
        /// </summary>
        /// <param name="putUserAuthorityReq">putUserAuthorityReq</param>
        /// <returns></returns>
        public Task<ResponseViewModel> UpdateStoreAuthority(PutUserAuthorityReq putUserAuthorityReq);

        /// <summary>
        /// 取得特店下拉式選單
        /// </summary>
        /// <param name="customerId">公司ID</param>
        /// <returns></returns>
        public Task<ResponseViewModel> GetStoreForDDL(string customerId);

    }
}
