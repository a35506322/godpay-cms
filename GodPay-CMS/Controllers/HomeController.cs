using GodPay_CMS.Controllers.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GodPay_CMS.Controllers
{
    [ResponseCache(NoStore = true)]
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        [Authorize]
        public IActionResult Index()
        {
            return View("Index", "Hello MVC");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
