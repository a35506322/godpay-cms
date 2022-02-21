using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.DTO.Request;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Admin,Manager")]
    [ProducesResponseType(typeof(ResponseViewModel), 200)]
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
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpGet]   
        public async Task<IActionResult> GetAll()
        {
            var response = await _serviceWrapper.customerService.GetAll();
            return Ok(response);
        }

        /// <summary>
        /// 以流水號或CustomerId或公司名稱取得公司
        /// </summary>
        /// <param name="customerParams">customerParams</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CustomerParams customerParams)
        {
            var response = await _serviceWrapper.customerService.Get(customerParams);
            return Ok(response);
        }

        /// <summary>
        /// 新增公司
        /// </summary>
        /// <param name="postCustomerReq">postCustomerReq</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostCustomerReq postCustomerReq)
        {
            var response = await _serviceWrapper.customerService.Add(postCustomerReq);
            return Ok(response);
        }

        /// <summary>
        /// 編輯公司
        /// </summary>
        /// <param name="putCustomerReq">putCustomerReq</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] PutCustomerReq putCustomerReq)
        {
            var response = await _serviceWrapper.customerService.Edit(putCustomerReq);

            return Ok(response);
        }
    }
}
