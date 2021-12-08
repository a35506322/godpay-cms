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
    public class ManagerSetApiController : Controller
    {
        private readonly IServiceWrapper _serviceWrapper;
        public ManagerSetApiController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        /// <summary>
        /// 取得所有業務
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetManagerAll()
        {
            var response = await _serviceWrapper.managerService.GetManagerAll();
            return Ok(response);
        }
        /// <summary>
        /// 取得單筆業務詳細資料
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetManagerDeatil([FromQuery] int uid)
        {
            var response = await _serviceWrapper.managerService.GetManagerDeatil(uid);
            return Ok(response);
        }
        /// <summary>
        /// 新增業務
        /// </summary>
        /// <param name="postUserAndInsiderViewModal"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostManager([FromBody] PostUserAndInsiderViewModel postUserAndInsiderViewModal)
        {
            var response = await _serviceWrapper.managerService.PostManagerAndInsider(postUserAndInsiderViewModal);
            return Ok(response);
        }
        /// <summary>
        /// 取得單筆業務
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetManager([FromQuery] string userId)
        {
            var response = await _serviceWrapper.managerService.GetManagerAndInsiderByUserId(userId);
            return Ok(response);
        }
        /// <summary>
        /// 更新業務
        /// </summary>
        /// <param name="updateUserAndInsiderViewModal"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateManager([FromBody] UpdateUserAndInsiderViewModel updateUserAndInsiderViewModal)
        {
            var response = await _serviceWrapper.managerService.UpdateManagerAndInsider(updateUserAndInsiderViewModal);
            return Ok(response);
        }
        /// <summary>
        /// 取得單筆業務(塞選)
        /// </summary>
        /// <param name="userParams"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetManagerFilter([FromQuery] UserParams userParams)
        {
            var response = await _serviceWrapper.managerService.GetManagerFilter(userParams);
            return Ok(response);
        }
    }
}
