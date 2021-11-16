using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    public class SigninController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Sign In";
            return View();
        }
    }
}
