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
    [Authorize(Roles = "Admin,Manager")]
    public class StoreManagementApiController : Controller
    {
        private readonly IServiceWrapper _serviceWrapper;
        public StoreManagementApiController(IServiceWrapper serviceWrapper)
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
        /// 新增特店
        /// </summary>
        /// <param name="postUserAndStoreViewModal"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostStore([FromBody] PostUserAndStoreViewModel postUserAndStoreViewModal)
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
        /// 取得特店資訊](篩選)
        /// </summary>
        /// <param name="userParams"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStoreFilter([FromQuery] UserParams userParams)
        {
            var response = await _serviceWrapper.storeService.GetStoreFilter(userParams);
            return Ok(response);
        }
        /// <summary>
        /// 更新特店
        /// </summary>
        /// <param name="updateUserAndStoreViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateStore([FromBody] UpdateUserAndStoreViewModel updateUserAndStoreViewModel)
        {
            var reponse = await _serviceWrapper.storeService.UpateUserAndStore(updateUserAndStoreViewModel);
            return Ok(reponse);
        }
    }
}
