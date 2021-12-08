using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GodPay_CMS.Controllers
{
    /// <summary>
    /// 特店管理頁面
    /// </summary>
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
