using System.Threading.Tasks;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GodPay_CMS.Controllers
{
    /// <summary>
    /// 特店人員管理API
    /// </summary>
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Admin,Manager,Store")]
    [ProducesResponseType(typeof(ResponseViewModel), 200)]
    public class PersonnelSetApiController : Controller
    {
        private readonly IServiceWrapper _serviceWrapper;
        public PersonnelSetApiController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        /// <summary>
        /// 取得特店的特店人員
        /// </summary>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStorePersonnels()
        {
            var response = await _serviceWrapper.personnelService.GetAllPersonnelByStore();
            return Ok(response);
        }

        /// <summary>
        /// 新增特店的特店人員
        /// </summary>
        /// <param name="postStorePersonnelViewModel">postStorePersonnelViewModel</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostStorePersonnel([FromBody]PostStorePersonnelViewModel postStorePersonnelViewModel)
        {
            var response = await _serviceWrapper.personnelService.PostStorePersonnel(postStorePersonnelViewModel);
            return Ok(response);
        }

        /// <summary>
        /// 修改特店的特店人員
        /// </summary>
        /// <param name="updateStorePersonnelViewModel">updateStorePersonnelViewModel</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateStorePersonnel([FromBody] UpdateStorePersonnelViewModel updateStorePersonnelViewModel)
        {
            var response = await _serviceWrapper.personnelService.UpdateStorePersonnel(updateStorePersonnelViewModel);
            return Ok(response);
        }

        /// <summary>
        /// 取得特店人員單筆權限
        /// </summary>
        /// <param name="userId">userId</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStorePersonnelAuthority([FromQuery] string userId)
        {
            var response = await _serviceWrapper.personnelService.GetStorePersonnelAuthority(userId);
            return Ok(response);
        }

        /// <summary>
        /// 修改特店人員角色權限
        /// </summary>
        /// <param name="updateUserAuthorityViewModel">updateUserAuthorityViewModel</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateStorePersonnelAuthority([FromBody] UpdateUserAuthorityViewModel updateUserAuthorityViewModel)
        {
            var response = await _serviceWrapper.personnelService.UpdateStorePersonnelAuthority(updateUserAuthorityViewModel);
            return Ok(response);
        }
    }
}
