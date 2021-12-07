using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GodPay_CMS.Controllers
{
    [ResponseCache(NoStore = true)]
    [Authorize]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
