using GodPay.Domain.Dto;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    [ProducesResponseType(typeof(ResponseViewModel), 200)]
    public class TransactionRecordApiController : Controller
    {
        private readonly IServiceWrapper _serviceWrapper;
        public TransactionRecordApiController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        /// <summary>
        /// 取得訂單
        /// </summary>
        /// <param name="glbdQueryOrdersReq">訂單QuerString</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Manager,Store")]
        public async Task<IActionResult> GetOrdersCondition([FromQuery] GLBDQueryOrdersReq glbdQueryOrdersReq)
        {
            var response = await _serviceWrapper.glbd_OperationAndTransactionRecordService.GetOrdersCondition(glbdQueryOrdersReq);
            return Ok(response);
        }

        /// <summary>
        /// 退貨
        /// </summary>
        /// <param name="glbdRefundReq">退貨</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Store")]
        public async Task<IActionResult> Refund([FromBody] GLBDRefundReq glbdRefundReq)
        {
            var response = await _serviceWrapper.glbd_OperationAndTransactionRecordService.Refund(glbdRefundReq);
            return Ok(response);
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="glbdRefundReq">退貨</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Store")]
        public async Task<IActionResult> Void([FromBody] GLBDVoidReq glbdVoidReq)
        {
            var response = await _serviceWrapper.glbd_OperationAndTransactionRecordService.Void(glbdVoidReq);
            return Ok(response);
        }
    }
}
