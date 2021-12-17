using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GodPay_CMS.Controllers
{
    /// <summary>
    /// 轉換Enum
    /// </summary>
    [Route("[controller]/[action]")]
    [Authorize]
    public class EnumApiController : Controller
    {
        private readonly IServiceWrapper _serviceWrapper;
        public EnumApiController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        /// <summary>
        /// 取得角色
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetRoleEnum() => Ok(_serviceWrapper.enumService.GetRoleEnum());

        /// <summary>
        /// 取得帳號狀態
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAccountStatusEnum() => Ok(_serviceWrapper.enumService.GetAccountStatusEnum());
    }
}
