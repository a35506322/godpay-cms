using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    [Authorize]
    public class BusinessManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 業務列表
        /// </summary>
        /// <returns></returns>
        public IActionResult BusinessList()
        {
            return View();
        }
    }
}
