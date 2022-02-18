using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Interfaces
{
    /// <summary>
    /// User存儲庫
    /// </summary>
    public interface IUserRepository : IGenericRepository<User>, IGenericRepositoryById<User, int>
    {
        /// <summary>
        /// 查詢使用者帳號密碼
        /// </summary>
        /// <param name="signinReq"></param>
        /// <returns></returns>
        public Task<User> GetByUserIdAndUserKey(User user);

        /// <summary>
        /// 紀錄登入時間
        /// </summary>
        /// <param name="signinReq"></param>
        /// <returns></returns>
        public Task<int> UpdateLoginTime(User userReq);

        /// <summary>
        /// 以帳號取得使用者資訊
        /// </summary>
        /// <param name="userId">帳號</param>
        /// <returns></returns>
        public Task<User> GetByUserId(string userId);

        /// <summary>
        /// 變更使用者資訊
        /// </summary>
        /// <param name="updateUserReq"></param>
        /// <returns></returns>
        public Task<int> UpdateUser(UpdateUserReq updateUserReq);

        /// <summary>
        /// 使用者變更密碼
        /// </summary>
        /// <param name="editKeyViewModel"></param>
        /// <returns></returns>
        public Task<int> UpdateKey(EditKeyViewModel editKeyViewModel);

        /// <summary>
        /// 新增業務使用者及詳細資料
        /// </summary>
        /// <param name="userAndInsiderReq"></param>
        /// <returns></returns>
        public Task<bool> PostUserAndInsider(PostUserAndInsiderReq userAndInsiderReq);

        /// <summary>
        /// 查詢單筆使用者及業務詳細資料(Join)
        /// </summary>
        /// <param name="userId">帳號</param>
        /// <returns></returns>
        public Task<User> GetUserAndInsiderByUserId(string userId);

        /// <summary>
        /// 修改業務使用者及詳細資料
        /// </summary>
        /// <param name="updateUserAndInsiderReq"></param>
        /// <returns></returns>
        public Task<bool> UpdateUserAndInsider(UpdateUserAndInsiderReq updateUserAndInsiderReq);

        /// <summary>
        /// 新增特店使用者及詳細資料
        /// </summary>
        /// <param name="postUserAndStoreReq"></param>
        /// <returns></returns>
        public Task<bool> PostUserAndStore(PostUserAndStoreReq postUserAndStoreReq);

        /// <summary>
        /// 取得使用者們篩選資料
        /// </summary>
        /// <param name="businessmanParams">Query</param>
        /// <returns></returns>
        public Task<IEnumerable<User>> GetUsersFilter(UserParams userParams);

        /// <summary>
        /// 查詢單筆業務及特約商店詳細資料
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<User> GetUserAndStoreByUserId(string userId);

        /// <summary>
        /// 修改特約商店詳細資料
        /// </summary>
        /// <param name="updateUserAndStoreReq"></param>
        /// <returns></returns>
        public Task<bool> UpateUserAndStore(UpdateUserAndStoreReq updateUserAndStoreReq);

        /// <summary>
        /// 修改使用者權限
        /// </summary>
        /// <param name="updateUserAuthorityReq"></param>
        /// <returns></returns>
        public Task<bool> UpdateUserAuthority(User updateUserAuthorityReq);

        /// <summary>
        /// 新增特店人員
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<bool> PostStorePersonnel(User user);

        /// <summary>
        /// 修改特店人員
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<bool> UpdateStorePersonnel(User user);
    }
}
