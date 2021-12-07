using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GodPay_CMS.Controllers
{
    [ResponseCache(NoStore = true)]
    [Authorize(Roles = "Admin")]
    public class BusinessManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
