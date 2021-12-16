using AutoMapper;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
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
