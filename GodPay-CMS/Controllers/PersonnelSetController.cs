using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GodPay_CMS.Controllers
{
    /// <summary>
    /// 特店人員管理頁面
    /// </summary>
    [Authorize(Roles = "Store")]
    public class PersonnelSetController : Controller
    {
        /// <summary>
        /// 特店人員首頁
        /// </summary>
        /// <returns></returns>
        [ResponseCache(NoStore = true)]    
        public IActionResult Index()
        {
            return View();
        }
    }
}
