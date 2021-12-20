using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    [Route("[controller]/[action]")]
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
        public async Task<IActionResult> Get([FromQuery] CustomerParams customerParams)
        {
            var response = await _serviceWrapper.customerService.Get(customerParams);

            return Ok(response);
        }

        /// <summary>
        /// 新增公司
        /// </summary>
        /// <param name="customerName">公司名稱</param>
        /// <returns></returns>
        public async Task<IActionResult> Post(string customerName)
        {
            var response = await _serviceWrapper.customerService.Add(customerName);

            return Ok(response);
        }
    }
}
