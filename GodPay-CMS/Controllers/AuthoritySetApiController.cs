﻿using AutoMapper;
using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    /// <summary>
    /// 權限管理伺服器
    /// </summary>
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
        /// 取得所有功能權限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListOfFunction()
        {
            var response = await _serviceWrapper.authorityService.GetListOfFunctions();
            return Ok(response);
        }
        /// <summary>
        /// 取得塞選功能權限
        /// </summary>
        /// <param name="functionParams"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListOfFunctionFilter([FromQuery]FunctionParams functionParams)
        {
            var response =  await _serviceWrapper.authorityService.GetListOfFunctionsFilter(functionParams);
            return Ok(response);
        }
        /// <summary>
        /// 批次修改最大權限
        /// </summary>
        /// <param name="functionParams"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateRoleMaxAuthority([FromBody] IEnumerable<UpdateFuncClassViewModel> updateFuncClassViewModels)
        {
            var response = await _serviceWrapper.authorityService.UpdateRoleMaxAuthority(updateFuncClassViewModels);
            return Ok(response);
        }
        /// <summary>
        /// 取得所有功能類別
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListOfFuncClass()
        {
            var response = await _serviceWrapper.authorityService.GetListOfFuncClass();
            return Ok(response);
        }
        /// <summary>
        /// 新增功能類別
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> PostFuncClass([FromBody] PostFuncClassViewModel postFuncClassViewModel)
        {
            var response = await _serviceWrapper.authorityService.PostFuncClass(postFuncClassViewModel);
            return Ok(response);
        }
    }
}