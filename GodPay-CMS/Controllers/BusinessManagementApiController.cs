using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    /// <summary>
    /// 業務管理Api
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class BusinessManagementApiController : Controller
    {
        private readonly IServiceWrapper _serviceWrapper;
        public BusinessManagementApiController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        /// <summary>
        /// 取得所有業務
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetBusinessmens()
        {
            var response = await _serviceWrapper.businessManagementService.GetBusinessmens();
            return Ok(response);
        }
        /// <summary>
        /// 取得單筆業務詳細資料
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetBusinessmenDeatil([FromQuery] int uid)
        {
            var response = await _serviceWrapper.businessManagementService.GetBusinessmenDeatil(uid);
            return Ok(response);
        }
        /// <summary>
        /// 新增業務
        /// </summary>
        /// <param name="postUserAndInsiderViewModal"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostBusinessmen([FromBody] PostUserAndInsiderViewModel postUserAndInsiderViewModal)
        {
            var response = await _serviceWrapper.businessManagementService.PostBusinessmanAndInsider(postUserAndInsiderViewModal);
            return Ok(response);
        }
        /// <summary>
        /// 取得單筆業務
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetBusinessmen([FromQuery] string userId)
        {
            var response = await _serviceWrapper.businessManagementService.GetUserAndInsiderByUserId(userId);
            return Ok(response);
        }
        /// <summary>
        /// 更新業務
        /// </summary>
        /// <param name="updateUserAndInsiderViewModal"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateBusinessmen([FromBody] UpdateUserAndInsiderViewModel updateUserAndInsiderViewModal)
        {
            var response = await _serviceWrapper.businessManagementService.UpdateBusinessmanAndInsider(updateUserAndInsiderViewModal);
            return Ok(response);
        }
        /// <summary>
        /// 取得單筆業務(塞選)
        /// </summary>
        /// <param name="userParams"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetBusinessmensFilter([FromQuery] UserParams userParams)
        {
            var response = await _serviceWrapper.businessManagementService.GetBusinessmensFilter(userParams);
            return Ok(response);
        }
    }
}
