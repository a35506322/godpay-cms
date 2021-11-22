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
    [Authorize]
    public class BusinessManagementOperateController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IServiceWrapper _serviceWrapper;
        public BusinessManagementOperateController(IMapper mapper, IServiceWrapper serviceWrapper)
        {
            _mapper = mapper;
            _serviceWrapper = serviceWrapper;
        }

        public async Task<IActionResult> GetUsersByRole([FromQuery] RoleEnum role)
        {
            var response =  await _serviceWrapper.businessManagementService.GetUsersByRole(role);
            return Ok(response);
        }
    }
}
