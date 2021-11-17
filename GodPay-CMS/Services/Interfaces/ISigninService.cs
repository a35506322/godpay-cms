using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Interfaces
{
    public interface ISigninService
    {
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="signinReq"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> SigninUser(SigninReq signinReq);
    }
}
