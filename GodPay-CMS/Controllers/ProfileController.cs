using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 編輯使用者
        /// </summary>
        /// <returns></returns>
        public IActionResult EditUser()
        {
            return View();
        }
    }
}
