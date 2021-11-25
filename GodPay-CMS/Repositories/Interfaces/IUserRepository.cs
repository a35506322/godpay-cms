using GodPay_CMS.Common.Enums;
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
        public Task<User> GetByUserIdAndUserKey(SigninReq signinReq);
        /// <summary>
        /// 以帳號取得使用者資訊
        /// </summary>
        /// <param name="userId">帳號</param>
        /// <returns></returns>
        public Task<User> GetByUserId(string userId);
        /// <summary>
        /// 以角色取得使用者資訊列表
        /// </summary>
        /// <param name="role">角色</param>
        /// <returns></returns>
        public Task<IEnumerable<User>> GetByRole(RoleEnum role);
        /// <summary>
        /// 變更使用者資訊
        /// </summary>
        /// <param name="updateUserReq"></param>
        /// <returns></returns>
        public Task<int> UpdateUser(UpdateUserReq updateUserReq);
        /// <summary>
        /// 新增業務使用者及詳細資料
        /// </summary>
        /// <param name="userAndInsiderReq"></param>
        /// <returns></returns>
        public Task<bool> PostBusinessmanBAndInsider(PostUserAndInsiderReq userAndInsiderReq);
    }
}
