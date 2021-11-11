using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>, IGenericRepositoryById<User, int>
    {
        Task<UserRsp> GetByUserIdAndUserKey(SigninReq signinReq);
    }
}
