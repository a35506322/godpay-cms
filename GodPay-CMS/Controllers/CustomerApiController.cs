using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Admin,Manager")]
    public class CustomerApiController : Controller
    {
        private readonly IServiceWrapper _serviceWrapper;
        public CustomerApiController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        /// <summary>
        /// 取得所有公司
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseViewModel), 200)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _serviceWrapper.customerService.GetAll();
            return Ok(response);
        }

        /// <summary>
        /// 以流水號或CustomerId取得公司
        /// </summary>
        /// <param name="customerParams">流水號或CustomerId</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseViewModel), 200)]
        public async Task<IActionResult> Get([FromQuery] CustomerParams customerParams)
        {
            var response = await _serviceWrapper.customerService.Get(customerParams);
            return Ok(response);
        }

        /// <summary>
        /// 新增公司
        /// </summary>
        /// <param name="addCustomerViewModel">公司名稱</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseViewModel), 200)]
        public async Task<IActionResult> Post([FromBody] AddCustomerViewModel addCustomerViewModel)
        {
            var response = await _serviceWrapper.customerService.Add(addCustomerViewModel);
            return Ok(response);
        }

        /// <summary>
        /// 編輯公司
        /// </summary>
        /// <param name="editCustomerViewModel">EditCustomerViewModel</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ResponseViewModel), 200)]
        public async Task<IActionResult> Edit([FromBody] EditCustomerViewModel editCustomerViewModel)
        {
            var response = await _serviceWrapper.customerService.Edit(editCustomerViewModel);

            return Ok(response);
        }
    }
}
