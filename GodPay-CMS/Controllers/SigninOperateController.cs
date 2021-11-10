using AutoMapper;
using GodPay_CMS.Controllers.ViewModels;
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
        public IActionResult SignIn([FromBody] UserViewModel userViewModel)
        {
            return Ok(userViewModel);
        }
    }
}
