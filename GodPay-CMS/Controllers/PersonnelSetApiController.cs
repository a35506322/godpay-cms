using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GodPay_CMS.Controllers
{
    /// <summary>
    /// 特店人員管理API
    /// </summary>
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Admin,Manager,Store")]
    public class PersonnelSetApiController : Controller
    {
        private readonly IServiceWrapper _serviceWrapper;
        public PersonnelSetApiController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

    }
}
