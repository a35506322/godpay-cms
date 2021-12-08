using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GodPay_CMS.Controllers
{
    /// <summary>
    /// 使用者管理頁面
    /// </summary>
    [ResponseCache(NoStore = true)]
    [Authorize]
    public class ProfileController : Controller
    {
        /// <summary>
        /// 單筆首頁
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
