using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Common.Helpers;
using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.Interfaces;
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
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = ReturnCodeEnum.NotFound.GetEnumDescription() };

            return new ResponseViewModel() { RtnData = customers };
        }

        public async Task<ResponseViewModel> Get(CustomerParams customerParams)
        {
            var customer = await _repostioryWrapper.customerRepository.Get(customerParams);

            if (customer == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = ReturnCodeEnum.NotFound.GetEnumDescription() };

            return new ResponseViewModel() { RtnData = customer };
        }

        public async Task<ResponseViewModel> Add(AddCustomerViewModel addCustomerViewModel)
        {
            var customerParams = _mapper.Map<CustomerParams>(addCustomerViewModel);
            var customer = await _repostioryWrapper.customerRepository.Get(customerParams);
            if (customer != null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.SameNameFail, RtnMessage= ReturnCodeEnum.SameNameFail.GetEnumDescription(), RtnData = "公司名稱重覆" };

            Customer customerReq = _mapper.Map<Customer>(addCustomerViewModel);

            var result = await _repostioryWrapper.customerRepository.Add(customerReq);

            if (result == false)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = ReturnCodeEnum.ExecutionFail.GetEnumDescription()};

            return new ResponseViewModel();
        }

        public async Task<ResponseViewModel> Edit(EditCustomerViewModel editCustomerViewModel)
        {
            var customerParams = _mapper.Map<CustomerParams>(editCustomerViewModel);

            var customer = await _repostioryWrapper.customerRepository.Get(customerParams);

            if (customer == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = ReturnCodeEnum.NotFound.GetEnumDescription() };

            var customerReq = _mapper.Map<Customer>(editCustomerViewModel);

            var result = await _repostioryWrapper.customerRepository.Update(customerReq);

            if (result == false)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = ReturnCodeEnum.ExecutionFail.GetEnumDescription() };

            return new ResponseViewModel() { RtnMessage = "修改公司成功" };
        }
    }
}
