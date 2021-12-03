using AutoMapper;
using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    [Authorize]
    public class AuthorityApiController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IServiceWrapper _serviceWrapper;
        public AuthorityApiController(IMapper mapper, IServiceWrapper serviceWrapper)
        {
            _mapper = mapper;
            _serviceWrapper = serviceWrapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListOfFunction()
        {
            var response = await _serviceWrapper.authorityService.GetListOfFunctions();
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetListOfFunctionFilter([FromQuery]FunctionParams functionParams)
        {
            var response =  await _serviceWrapper.authorityService.GetListOfFunctionsFilter(functionParams);
            return Ok(response);
        }
    }
}
