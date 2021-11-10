using AutoMapper;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GodPay_CMS.Controllers
{
    public class SigninOperateController : Controller
    {
        private readonly IMapper _mapper;
        public SigninOperateController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult SignIn([FromBody] SigninViewModel signinViewModel)
        {
            var signinReq = _mapper.Map<SigninReq>(signinViewModel);

            ResponseViewModel<SigninViewModel> responseViewModel = new ResponseViewModel<SigninViewModel>();
            responseViewModel.RtnCode = Common.Enums.ReturnCodeEnum.Success;
            responseViewModel.RtnMessage = "Server驗證成功";
            responseViewModel.RtnData = signinViewModel;
            return Ok(responseViewModel);
        }
    }
}
