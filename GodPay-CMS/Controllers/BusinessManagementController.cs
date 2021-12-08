using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GodPay_CMS.Controllers
{
    /// <summary>
    /// 業務管理頁面
    /// </summary>
    [ResponseCache(NoStore = true)]
    [Authorize(Roles = "Admin")]
    public class BusinessManagementController : Controller
    {
        /// <summary>
        /// 業務管理首頁
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
