using AutoMapper;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GodPay_CMS.Controllers
{
    [Route("[controller]/[action]")]
    public class CustomerApiController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IServiceWrapper _serviceWrapper;
        public CustomerApiController(IMapper mapper, IServiceWrapper serviceWrapper)
        {
            _mapper = mapper;
            _serviceWrapper = serviceWrapper;
        }
    }
}
