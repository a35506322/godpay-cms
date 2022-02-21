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
    /// 業務管理Api
    /// </summary>
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ResponseViewModel), 200)]
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
        /// <response code="200">連線成功</response>
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
        /// <param name="uid">uid</param>
        /// <response code="200">連線成功</response>
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
        /// <param name="postUserAndInsiderReq">postUserAndInsiderReq</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostManagerAndInsider([FromBody] PostUserAndInsiderReq postUserAndInsiderReq)
        {
            var response = await _serviceWrapper.managerService.PostManagerAndInsider(postUserAndInsiderReq);
            return Ok(response);
        }

        /// <summary>
        /// 取得單筆業務
        /// </summary>
        /// <param name="userId">userId</param>
        /// <response code="200">連線成功</response>
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
        /// <param name="putUserAndInsiderReq">putUserAndInsiderReq</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateManagerAndInsider([FromBody] PutUserAndInsiderReq putUserAndInsiderReq)
        {
            var response = await _serviceWrapper.managerService.UpdateManagerAndInsider(putUserAndInsiderReq);
            return Ok(response);
        }

        /// <summary>
        /// 取得業務角色權限
        /// </summary>
        /// <param name="userId">userId</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetManagerAuthority([FromQuery] string userId)
        {
            var response = await _serviceWrapper.managerService.GetManagerAuthority(userId);
            return Ok(response);
        }

        /// <summary>
        /// 修改業務角色權限
        /// </summary>
        /// <param name="putUserAuthorityReq">putUserAuthorityReq</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateManagerAuthority([FromBody] PutUserAuthorityReq putUserAuthorityReq)
        {
            var response = await _serviceWrapper.managerService.UpdateManagerAuthority(putUserAuthorityReq);
            return Ok(response);
        }
    }
}
