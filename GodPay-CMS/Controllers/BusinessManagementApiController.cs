using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.Parameters;
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
    [Authorize]
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
        public async Task<IActionResult> GetBusinessmenDeatil([FromQuery] int uid)
        {
            var response = await _serviceWrapper.businessManagementService.GetBusinessmenDeatil(uid);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostBusinessmen([FromBody] PostUserAndInsiderViewModel postUserAndInsiderViewModal)
        {
            var response = await _serviceWrapper.businessManagementService.PostBusinessmanAndInsider(postUserAndInsiderViewModal);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetBusinessmen([FromQuery] string userId)
        {
            var response = await _serviceWrapper.businessManagementService.GetUserAndInsiderByUserId(userId);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBusinessmen([FromBody] UpdateUserAndInsiderViewModel updateUserAndInsiderViewModal)
        {
            var response = await _serviceWrapper.businessManagementService.UpdateBusinessmanAndInsider(updateUserAndInsiderViewModal);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetBusinessmensFilter([FromQuery] BusinessmanParams businessmanParams)
        {
            var response = await _serviceWrapper.businessManagementService.GetBusinessmensFilter(businessmanParams);
            return Ok(response);
        }
    }
}
