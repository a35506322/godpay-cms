using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Interfaces
{
    public interface IGenericRepositoryById<T,TId> where T : class
    {
        public Task<T> GetById(TId id);

        public Task<bool> Delete(TId id);
    
    }
}
