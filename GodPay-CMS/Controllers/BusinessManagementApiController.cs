using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    [AllowAnonymous]
    public class BusinessManagementApiController : Controller
    {
        private readonly IServiceWrapper _serviceWrapper;
        public BusinessManagementApiController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBusinessmens()
        {
            var response = await _serviceWrapper.businessManagementService.GetBusinessmens();
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetBusinessmenDeatil([FromQuery] string userId)
        {
            var response = await _serviceWrapper.businessManagementService.GetBusinessmenDeatil(userId);
            return Ok(response);
        }
    }
}
