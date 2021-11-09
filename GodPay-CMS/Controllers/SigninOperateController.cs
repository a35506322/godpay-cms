using AutoMapper;
using GodPay_CMS.Controllers.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GodPay_CMS.Controllers
{
    public class SigninOperateController : Controller
    {
        private readonly IMapper mapper;
        public SigninOperateController(IMapper Mapper)
        {
            mapper = Mapper;
        }

        [HttpPost]
        public IActionResult SignIn([FromBody] UserViewModel UserViewModel)
        {
            return Ok(UserViewModel);
        }
    }
}
