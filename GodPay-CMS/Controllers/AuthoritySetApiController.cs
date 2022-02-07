using AutoMapper;
using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    /// <summary>
    /// 權限管理伺服器
    /// </summary>
    [Route("[controller]/[action]")]
    [ProducesResponseType(typeof(ResponseViewModel), 200)]
    public class AuthoritySetApiController : Controller

    {
        private readonly IMapper _mapper;
        private readonly IServiceWrapper _serviceWrapper;
        public AuthoritySetApiController(IMapper mapper, IServiceWrapper serviceWrapper)
        {
            _mapper = mapper;
            _serviceWrapper = serviceWrapper;
        }

        /// <summary>
        /// 取得所有功能權限(權限驗證)
        /// </summary>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetListOfFunctionsForAuthority()
        {
            var response = await _serviceWrapper.authorityService.GetListOfFunctionsForAuthority();
            return Ok(response);
        }

        /// <summary>
        /// 取得篩選功能權限
        /// </summary>
        /// <param name="functionParams">functionParams</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Store")]
        public async Task<IActionResult> GetListOfFunctionFilter([FromQuery] FunctionParams functionParams)
        {
            var response = await _serviceWrapper.authorityService.GetListOfFunctionsFilter(functionParams);
            return Ok(response);
        }

        /// <summary>
        /// 批次修改最大權限
        /// </summary>
        /// <param name="functionParams">functionParams</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRoleMaxAuthority([FromBody] IEnumerable<UpdateAuthorityClassViewModel> updateAuthorityClassViewModels)
        {
            var response = await _serviceWrapper.authorityService.UpdateRoleMaxAuthority(updateAuthorityClassViewModels);
            return Ok(response);
        }

        /// <summary>
        /// 取得所有功能類別
        /// </summary>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetListOfFuncClass()
        {
            var response = await _serviceWrapper.authorityService.GetListOfFuncClass();
            return Ok(response);
        }

        /// <summary>
        /// 新增功能類別
        /// </summary>
        /// <param name="functionParams">postFuncClassViewModel</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostFuncClass([FromBody] PostFuncClassViewModel postFuncClassViewModel)
        {
            var response = await _serviceWrapper.authorityService.PostFuncClass(postFuncClassViewModel);
            return Ok(response);
        }

        /// <summary>
        /// 取得特定功能類別
        /// </summary>
        /// <param name="funcCode">funcCode</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetFuncClassDetailById([FromQuery] string funcCode)
        {
            var reponse = await _serviceWrapper.authorityService.GetFuncClassDetailById(funcCode);
            return Ok(reponse);
        }

        /// <summary>
        /// 編輯功能類別
        /// </summary>
        /// <param name="updateFuncClassViewModel">updateFuncClassViewModel</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateFuncClass([FromBody] UpdateFuncClassViewModel updateFuncClassViewModel)
        {
            var response = await _serviceWrapper.authorityService.UpdateFuncClass(updateFuncClassViewModel);
            return Ok(response);
        }

        /// <summary>
        /// 取得所有功能
        /// </summary>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetListOfFunc()
        {
            var response = await _serviceWrapper.authorityService.GetListOfFunc();
            return Ok(response);
        }

        /// <summary>
        /// 取得個別功能資料
        /// </summary>
        /// <param name="fid">流水號</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetFuncDetailById([FromQuery]int fid)
        {
            var response = await _serviceWrapper.authorityService.GetFuncDetailById(fid);
            return Ok(response);
        }

        /// <summary>
        /// 修改功能
        /// </summary>
        /// <param name="updateFuncViewModel">updateFuncViewModel</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateFunc([FromBody] UpdateFuncViewModel updateFuncViewModel)
        {
            var response = await _serviceWrapper.authorityService.UpdateFunc(updateFuncViewModel);
            return Ok(response);
        }

        /// <summary>
        /// 新增功能
        /// </summary>
        /// <param name="postFuncViewModel">postFuncViewModel</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostFunc([FromBody]PostFuncViewModel postFuncViewModel)
        {
            var response = await _serviceWrapper.authorityService.PostFunc(postFuncViewModel);
            return Ok(response);
        }

    }
}
