using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.DTO;
using GodPay_CMS.Services.DTO.Request;
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
    [ProducesResponseType(typeof(ResponseViewModel), 200)]
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
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string userId)
        {
            var result = await _serviceWrapper.userService.GetUserByUserId(userId);
            return Ok(result);
        }

        /// <summary>
        /// 編輯使用者資訊
        /// </summary>
        /// <param name="putUserReq">putUserReq</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] PutUserReq putUserReq)
        {
            var result = await _serviceWrapper.userService.UpdateUser(putUserReq);
            return Ok(result);
        }

        /// <summary>
        /// 變更使用者密碼
        /// </summary>
        /// <param name="putEditKeyReq">putEditKeyReq</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditKey([FromBody] PutEditKeyReq putEditKeyReq)
        {
            var result = await _serviceWrapper.userService.UpdateKey(putEditKeyReq);
            return Ok(result);
        }

        /// <summary>
        /// 取得特店詳細資料
        /// </summary>
        /// <param name="uid">PK</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpGet]   
        public async Task<IActionResult> GetStoreDeatil([FromQuery] int uid)
        {
            var response = await _serviceWrapper.storeService.GetStoreDeatil(uid);
            return Ok(response);
        }

        /// <summary>
        /// 更新特店詳細資料
        /// </summary>
        /// <param name="putStoreReq"> putStoreReq</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateStoreDeatil([FromBody] PutStoreReq putStoreReq)
        {
            var response = await _serviceWrapper.storeService.UpateStore(putStoreReq);
            return Ok(response);
        }
    }
}
