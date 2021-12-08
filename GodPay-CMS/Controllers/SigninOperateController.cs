using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.DTO;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    /// <summary>
    /// 登入Api
    /// </summary>
    [AllowAnonymous]
    public class SigninOperateController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IServiceWrapper _serviceWrapper;
        public SigninOperateController(IMapper mapper, IServiceWrapper serviceWrapper)
        {
            _mapper = mapper;
            _serviceWrapper = serviceWrapper;
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="signinViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SigninViewModel signinViewModel)
        {
            var result = await _serviceWrapper.signinService.SigninUser(signinViewModel);

            if (result.RtnCode == ReturnCodeEnum.Ok)
            {
                UserRsp data = (UserRsp)result.RtnData;

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,data.UserId),
                    new Claim(ClaimTypes.Role,data.Role.ToString()),
                    new Claim("FuncFlag",data.Func.ToString())
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                    IsPersistent = true,
                };
                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity), authProperties);
            }
            return Ok(result);
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/Signin");
        }
    }
}
