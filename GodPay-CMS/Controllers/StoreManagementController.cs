using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    public class StoreManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 特店列表
        /// </summary>
        /// <returns></returns>
        public IActionResult StoreList()
        {
            return View();
        }
    }
}
