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
    public class EnumApiController : Controller
    {
        private readonly IServiceWrapper _serviceWrapper;
        public EnumApiController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [HttpGet]
        public IActionResult GetRoleEnum() => Ok(_serviceWrapper.enumService.GetRoleEnum());

        [HttpGet]
        public IActionResult GetAccountStatusEnum() => Ok(_serviceWrapper.enumService.GetAccountStatusEnum());
    }
}
