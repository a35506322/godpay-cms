﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GodPay_CMS.Controllers
{
    /// <summary>
    /// 特店管理頁面
    /// </summary>
    public class StoreSetController : Controller
    {
        /// <summary>
        /// 特店首頁
        /// </summary>
        /// <returns></returns>
        [ResponseCache(NoStore = true)]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
