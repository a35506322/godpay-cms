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
        /// 帳號
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 特店資訊
        /// </summary>
        /// <returns></returns>
        public IActionResult Store()
        {
            return View();
        }
    }
}
