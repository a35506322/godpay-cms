﻿using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.DTO;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GodPay_CMS.ViewComponents
{
    public class NavbarVertical : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthorityService _authorityService;
        public NavbarVertical(IHttpContextAccessor httpContextAccessor, IAuthorityService authorityService)
        {
            _httpContextAccessor = httpContextAccessor;
            _authorityService = authorityService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _authorityService.GetListOfFunctions();
            if (response.RtnCode == ReturnCodeEnum.Ok)
            {
                return View("NavbarVertical", response.RtnData as IEnumerable<FunctionListViewModel>);
            }
            else 
            {
                return View("NavbarVertical", new List<FunctionListViewModel>());
            }
        }
    }
}