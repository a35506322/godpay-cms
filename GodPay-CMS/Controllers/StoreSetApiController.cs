using GodPay_CMS.Controllers.Parameters;
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
        /// <param name="postUserAndStoreViewModal"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostUserAndStore([FromBody] PostUserAndStoreViewModel postUserAndStoreViewModal)
        {
            var response = await _serviceWrapper.storeService.PostUserAndStore(postUserAndStoreViewModal);
            return Ok(response);
        }

        /// <summary>
        /// 取得單筆特店
        /// </summary>
        /// <param name="userId">帳號</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStore([FromQuery] string userId)
        {
            var response = await _serviceWrapper.storeService.GetUserAndStoreByUserId(userId);
            return Ok(response);
        }

        /// <summary>
        /// 更新使用者及特店
        /// </summary>
        /// <param name="updateUserAndStoreViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpateUserAndStore([FromBody] UpdateUserAndStoreViewModel updateUserAndStoreViewModel)
        {
            var reponse = await _serviceWrapper.storeService.UpateUserAndStore(updateUserAndStoreViewModel);
            return Ok(reponse);
        }
    }
}
