using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    [Authorize(Roles = "Manager")]
    public class MemberController : Controller
    {
        /// <summary>
        /// 會員信額額度軌跡
        /// </summary>
        /// <returns></returns>
        public IActionResult MemberTrack()
        {
            return View();
        }
    }
}
