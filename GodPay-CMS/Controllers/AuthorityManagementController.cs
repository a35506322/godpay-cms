using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    public class AuthorityManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
