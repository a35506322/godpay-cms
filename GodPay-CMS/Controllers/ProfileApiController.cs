using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    /// <summary>
    /// 使用者管理Api
    /// </summary>
    [Route("[controller]")]
    [Authorize]
    public class ProfileApiController : Controller
    {
        private readonly IServiceWrapper _serviceWrapper;

        public ProfileApiController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        /// <summary>
        /// 取得使用者資訊
        /// </summary>
        /// <param name="userId">使用者帳號</param>
        /// <returns></returns>
        public async Task<IActionResult> Get([FromQuery] string userId)
        {
            var result = await _serviceWrapper.userService.GetUserByUserId(userId);
            return Ok(result);
        }

        /// <summary>
        /// 編輯使用者資訊
        /// </summary>
        /// <param name="editUserViewModel"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> Edit([FromBody] EditUserViewModel editUserViewModel)
        {
            var result = await _serviceWrapper.userService.UpdateUser(editUserViewModel);
            return Ok(result);
        }

        /// <summary>
        /// 變更使用者密碼
        /// </summary>
        /// <param name="editKeyViewModel"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> EditKey([FromBody] EditKeyViewModel editKeyViewModel)
        {
            var result = await _serviceWrapper.userService.UpdateKey(editKeyViewModel);
            return Ok(result);
        }
    }
}
