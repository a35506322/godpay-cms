using AutoMapper;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.DTO;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> SignIn([FromBody] SigninViewModel signinViewModel)
        {
            var signinReq = _mapper.Map<SigninReq>(signinViewModel);

            var result = await _serviceWrapper.signinService.SigninUser(signinReq);
            return Ok(result);
        }
    }
}
