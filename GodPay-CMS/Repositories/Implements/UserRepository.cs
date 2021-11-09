using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Implements
{
    public class UserRepository : IGenericRepository<User>, IGenericRepositoryById<User, int>, IUserRepository
    {
        public Task<bool> Add(User model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(User mdoel)
        {
            throw new NotImplementedException();
        }
    }
}
