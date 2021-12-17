using AutoMapper;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    [Route("[controller]/[action]")]
    public class CustomerApiController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IServiceWrapper _serviceWrapper;
        public CustomerApiController(IMapper mapper, IServiceWrapper serviceWrapper)
        {
            _mapper = mapper;
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
        /// 取得公司
        /// </summary>
        /// <param name="seqNo">流水號</param>
        /// <param name="customerId">CustomerId</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(int? seqNo, Guid? customerId)
        {
            if (seqNo == null && customerId == null)
                return BadRequest();

            var response = new ResponseViewModel();
            if (seqNo!=null)
                response = await _serviceWrapper.customerService.Get((int)seqNo);

            if(customerId!=null)
                response = await _serviceWrapper.customerService.Get((Guid)customerId);

            return Ok(response);
        }

    }
}
