﻿using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>, IGenericRepositoryById<User, int>
    {
        /// <summary>
        /// 查詢使用者帳號密碼
        /// </summary>
        /// <param name="signinReq"></param>
        /// <returns></returns>
        public Task<UserRsp> GetByUserIdAndUserKey(SigninReq signinReq);
    }
}
