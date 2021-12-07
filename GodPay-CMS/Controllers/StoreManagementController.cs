using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GodPay_CMS.Controllers
{
    public class StoreManagementController : Controller
    {
        [ResponseCache(NoStore = true)]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 特店列表
        /// </summary>
        /// <returns></returns>
        public IActionResult StoreList()
        {
            return View();
        }
    }
}
