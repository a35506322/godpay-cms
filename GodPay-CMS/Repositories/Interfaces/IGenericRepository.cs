using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T :class
    {
        public Task<IEnumerable<T>>  GetAll();
        public Task<bool> Add(T model);
        public Task<bool> Update(T mdoel);

    }
}
