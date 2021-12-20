using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.DTO;
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
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = "查無公司資料" };

            return new ResponseViewModel() { RtnData = customers };
        }

        public async Task<ResponseViewModel> Get(CustomerParams customerParams )
        {
            var customer = await _repostioryWrapper.customerRepository.Get(customerParams);

            if (customer == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = "查無公司資料" };

            return new ResponseViewModel() { RtnData = customer };
        }

        public async Task<ResponseViewModel> Add(string customerName)
        {
            var customer = await _repostioryWrapper.customerRepository.Get(customerName);
            if(customer!=null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.SameNameFail, RtnMessage = "公司名稱重覆" };

            CustomerReq customerReq = new CustomerReq() { CustomerName = customerName };

            var count = await _repostioryWrapper.customerRepository.AddCustomer(customerReq);

            if (count == 0)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "新增公司失敗" };

            return new ResponseViewModel();
        }
    }
}
