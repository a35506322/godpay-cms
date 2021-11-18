using GodPay_CMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO
{
    public class SigninReq
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        public string UserKey { get; set; }
        /// <summary>
        /// 帳號啟用狀態
        /// </summary>
        public AccountStatusEnum Status { get; set; } = AccountStatusEnum.Activate;
    }
}
