using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>, IGenericRepositoryById<User, int>
    {
        public Task<UserRsp> GetByUserIdAndUserKey(SigninReq signinReq);
    }
}
