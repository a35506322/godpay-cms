using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    /// <summary>
    /// 特店管理Api
    /// </summary>
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Admin,Manager")]
    [ProducesResponseType(typeof(ResponseViewModel), 200)]
    public class StoreSetApiController : Controller
    {
        private readonly IServiceWrapper _serviceWrapper;
        public StoreSetApiController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        /// <summary>
        /// 取得所有特店
        /// </summary>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            var response = await _serviceWrapper.storeService.GetStores();
            return Ok(response);
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
        /// 新增使用者及特店
        /// </summary>
        /// <param name="postUserAndStoreViewModal">postUserAndStoreViewModal</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostUserAndStore([FromBody] PostUserAndStoreViewModel postUserAndStoreViewModal)
        {
            //var response = await _serviceWrapper.storeService.PostUserAndStore(postUserAndStoreViewModal);
            //return Ok(response);
            return Ok();
        }

        /// <summary>
        /// 取得單筆特店
        /// </summary>
        /// <param name="userId">帳號</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStoreById([FromQuery] string userId)
        {
            var response = await _serviceWrapper.storeService.GetUserAndStoreByUserId(userId);
            return Ok(response);
        }

        /// <summary>
        /// 更新使用者及特店
        /// </summary>
        /// <param name="updateUserAndStoreViewModel">updateUserAndStoreViewModel</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpateUserAndStore([FromBody] UpdateUserAndStoreViewModel updateUserAndStoreViewModel)
        {
            var reponse = await _serviceWrapper.storeService.UpateUserAndStore(updateUserAndStoreViewModel);
            return Ok(reponse);
        }

        /// <summary>
        /// 取得特店角色權限
        /// </summary>
        /// <param name="userId">userId</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStoreAuthority([FromQuery] string userId)
        {
            var response = await _serviceWrapper.storeService.GetStoreAuthority(userId);
            return Ok(response);
        }

        /// <summary>
        /// 修改特店角色權限
        /// </summary>
        /// <param name="updateUserAuthorityViewModel">updateUserAuthorityViewModel</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateStoreAuthority([FromBody] UpdateUserAuthorityViewModel updateUserAuthorityViewModel)
        {
            var response = await _serviceWrapper.storeService.UpdateStoreAuthority(updateUserAuthorityViewModel);
            return Ok(response);
        }

        /// <summary>
        /// 取得特店下拉式選單
        /// </summary>
        /// <param name="customerId">公司Id</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStoreForDDL([FromQuery]string customerId)
        {
            var response = await _serviceWrapper.storeService.GetStoreForDDL(customerId);
            return Ok(response);
        }
    }
}
