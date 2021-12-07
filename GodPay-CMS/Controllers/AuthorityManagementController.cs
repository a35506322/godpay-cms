using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    public class AuthorityManagementController : Controller
    {
        public IActionResult AuthorityEdit()
        {
            return View();
        }

        public IActionResult ClassManagement()
        {
            return View();
        }

        public IActionResult FunctionManagement()
        {
            return View();
        }
    }
}
