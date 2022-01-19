using GodPay.Domain.Dto;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    [Authorize(Roles = "Manager,Store")]
    public class TransactionRecordApiController : Controller
    {
        private readonly IServiceWrapper _serviceWrapper;
        public TransactionRecordApiController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        /// <summary>
        /// 取得所有功能權限
        /// </summary>
        /// <param name="glbdQueryOrdersReq">訂單QuerString</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetOrdersCondition([FromQuery] GLBDQueryOrdersReq glbdQueryOrdersReq)
        {
            var response = await _serviceWrapper.glbd_OperationAndTransactionRecordService.GetOrdersCondition(glbdQueryOrdersReq);
            return Ok(response);
        }
    }
}
