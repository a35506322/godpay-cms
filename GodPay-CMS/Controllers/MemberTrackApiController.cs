using GodPay.Domain.Dto;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    /// <summary>
    /// 會員軌跡API
    /// </summary>
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Manager")]
    [ProducesResponseType(typeof(ResponseViewModel), 200)]
    public class MemberTrackApiController : Controller
    {
        private readonly IServiceWrapper _serviceWrapper;
        public MemberTrackApiController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMemberTrack([FromQuery]GLBDQueryMemberTracksReq gLBDQueryMemberTracksReq)
        {
            var result = await _serviceWrapper.memberTrackService.GetMemberTrack(gLBDQueryMemberTracksReq);
            return Ok(result);
        }
    }
}
