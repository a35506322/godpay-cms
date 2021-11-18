using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    public class SigninController : Controller
    {
        /// <summary>
        /// 登入首頁
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {            
            return View();
        }
    }
}
