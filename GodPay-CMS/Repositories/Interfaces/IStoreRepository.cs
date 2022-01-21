using GodPay_CMS.Repositories.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Interfaces
{
    public interface IStoreRepository : IGenericRepository<Customer_Store>, IGenericRepositoryById<Customer_Store, int>
    {
        Task<IEnumerable<Customer_Store>> GetStoresCondition(Customer_Store customer_Store);
    }
}
