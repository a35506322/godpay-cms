using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Customer>> GetAll();
        public Task<Customer> Get(int seqNo);
        public Task<Customer> Get(Guid customerId);
        public Task<Customer> Get(string customerName);
        public Task<int> AddCustomer(CustomerReq customerReq);
    }
}
