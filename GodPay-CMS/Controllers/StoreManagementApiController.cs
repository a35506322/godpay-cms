using GodPay_CMS.Controllers.Parameters;
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
    [Authorize]
    public class StoreManagementApiController : Controller
    {
        private readonly IServiceWrapper _serviceWrapper;
        public StoreManagementApiController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            var response = await _serviceWrapper.storeService.GetStores();
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetStoreDeatil([FromQuery] int uid)
        {
            var response = await _serviceWrapper.storeService.GetStoreDeatil(uid);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostStore([FromBody] PostUserAndStoreViewModel postUserAndStoreViewModal)
        {
            var response = await _serviceWrapper.storeService.PostUserAndStore(postUserAndStoreViewModal);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetStore([FromQuery] string userId)
        {
            var response = await _serviceWrapper.storeService.GetUserAndStoreByUserId(userId);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetStoreFilter([FromQuery] UserParams userParams)
        {
            var response = await _serviceWrapper.storeService.GetStoreFilter(userParams);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStore([FromBody] UpdateUserAndStoreViewModel updateUserAndStoreViewModel)
        {
            var reponse = await _serviceWrapper.storeService.UpateUserAndStore(updateUserAndStoreViewModel);
            return Ok(reponse);
        }
    }
}
