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
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    /// <summary>
    /// 登入Api
    /// </summary>
    [Route("[controller]/[action]")]
    [AllowAnonymous]
    public class SigninApiController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IServiceWrapper _serviceWrapper;
        private readonly ILogger<SigninApiController> _logger;

        public SigninApiController(IMapper mapper, IServiceWrapper serviceWrapper, ILogger<SigninApiController> logger)
        {
            _mapper = mapper;
            _serviceWrapper = serviceWrapper;
            _logger = logger;

        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="signinViewModel">signinViewModel</param>
        /// <response code="200">連線成功</response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseViewModel), 200)]
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
                    new Claim("FuncFlag",data.Func.ToString()),
                    new Claim("Uid",data.Uid.ToString())
                };

                if (data.Role == RoleEnum.Store)
                { 
                    var user = await _serviceWrapper.storeService.GetUserAndStoreByUserId(data.UserId);
                    claims.Add(new Claim("StoreId", ((StoreParticularsRsp)user.RtnData).StoreId.ToString()));
                    claims.Add(new Claim("CustomerId", ((StoreParticularsRsp)user.RtnData).CustomerId.ToString()));
                }
                    
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                    IsPersistent = true                   
                };
                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity), authProperties);

                _logger.LogInformation("Account:{Account} Message:{Message}", data.UserId, "登入成功");
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

            return Redirect("/signin");
        }
    }
}
