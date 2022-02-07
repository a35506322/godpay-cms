using GodPay_CMS.Controllers.ViewModels;
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
    [ProducesResponseType(typeof(ResponseViewModel), 200)]
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
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetRoleEnum() => Ok(_serviceWrapper.enumService.GetRoleEnum());

        /// <summary>
        /// 取得帳號狀態
        /// </summary>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAccountStatusEnum() => Ok(_serviceWrapper.enumService.GetAccountStatusEnum());
    }
}
