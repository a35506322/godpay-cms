using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
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
        public async Task<IActionResult> Get([FromBody] string userId)
        {
            var result = await _serviceWrapper.userService.GetUser(userId);
            return Ok(result);
        }

        /// <summary>
        /// 編輯使用者資訊
        /// </summary>
        /// <param name="editUserViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] EditUserViewModel editUserViewModel)
        {
            var result = await _serviceWrapper.userService.UpdateUser(editUserViewModel);
            return Ok(result);
        }
    }
}
