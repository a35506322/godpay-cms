using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.DTO;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    public class SigninOperateController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IServiceWrapper _serviceWrapper;
        public SigninOperateController(IMapper mapper, IServiceWrapper serviceWrapper)
        {
            _mapper = mapper;
            _serviceWrapper = serviceWrapper;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SigninViewModel signinViewModel, string url)
        {
            var signinReq = _mapper.Map<SigninReq>(signinViewModel);

            var result = await _serviceWrapper.signinService.SigninUser(signinReq);

            if (result.RtnCode == ReturnCodeEnum.Ok)
            {
                UserRsp data = (UserRsp)result.RtnData;
                Claim[] claims = new[]
                {
                    new Claim(ClaimTypes.Name,data.UserId),
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties authProperties = new AuthenticationProperties { };
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
