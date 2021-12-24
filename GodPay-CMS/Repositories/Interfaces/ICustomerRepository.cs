using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>, IGenericRepositoryById<Customer, int>
    {
        public Task<Customer> Get(CustomerParams customerParams);
    }
}
