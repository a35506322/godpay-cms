using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    /// <summary>
    /// 權限管理頁面
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class AuthoritySetController : Controller
    {
        /// <summary>
        /// 權限設定頁面
        /// </summary>
        /// <returns></returns>
        public IActionResult AuthorityEdit()
        {
            return View();
        }
        /// <summary>
        /// 類別編輯頁面
        /// </summary>
        /// <returns></returns>
        public IActionResult ClassManagement()
        {
            return View();
        }
        /// <summary>
        /// 功能編輯頁面
        /// </summary>
        /// <returns></returns>
        public IActionResult FunctionManagement()
        {
            return View();
        }
    }
}
