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
    [Route("[controller]/[action]")]
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
        [HttpPost]
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
        [HttpPost]
        public async Task<IActionResult> EditKey([FromBody] EditKeyViewModel editKeyViewModel)
        {
            var result = await _serviceWrapper.userService.UpdateKey(editKeyViewModel);
            return Ok(result);
        }

        /// <summary>
        /// 取得特店詳細資料
        /// </summary>
        /// <param name="uid">PK</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseViewModel), 200)]
        [HttpGet]
        public async Task<IActionResult> GetStoreDeatil([FromQuery] int uid)
        {
            var response = await _serviceWrapper.storeService.GetStoreDeatil(uid);
            return Ok(response);
        }

        /// <summary>
        /// 更新特店詳細資料
        /// </summary>
        /// <param name="updateStoreViewModel">更新特店資訊</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ResponseViewModel), 200)]
        public async Task<IActionResult> UpdateStoreDeatil([FromBody] UpdateStoreViewModel updateStoreViewModel)
        {
            var response = await _serviceWrapper.storeService.UpateStore(updateStoreViewModel);
            return Ok(response);
        }
    }
}
