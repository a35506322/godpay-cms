using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.ViewComponents
{
    public class Header : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthorityService _authorityService;
        public Header(IHttpContextAccessor httpContextAccessor, IAuthorityService authorityService)
        {
            _httpContextAccessor = httpContextAccessor;
            _authorityService = authorityService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Header");
        }
    }
}
