using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Implements
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly IRepostioryWrapper _repostioryWrapper;

        public CustomerService(IRepostioryWrapper repostioryWrapper, IMapper mapper)
        {
            _repostioryWrapper = repostioryWrapper;
            _mapper = mapper;
        }

        public async Task<ResponseViewModel> GetAll()
        {
            var customers = await _repostioryWrapper.customerRepository.GetAll();

            if (customers.Count() == 0)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = "查無公司資料" };

            return new ResponseViewModel() { RtnData = customers };
        }

        public async Task<ResponseViewModel> Get(int seqNo)
        {
            var customer = await _repostioryWrapper.customerRepository.Get(seqNo);

            if (customer == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = "查無公司資料" };

            return new ResponseViewModel() { RtnData = customer };
        }

        public async Task<ResponseViewModel> Get(Guid customerId)
        {
            var customer = await _repostioryWrapper.customerRepository.Get(customerId);

            if (customer == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = "查無公司資料" };

            return new ResponseViewModel() { RtnData = customer };
        }
    }
}
