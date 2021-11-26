using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO
{
    /// <summary>
    /// 使用者(Response)
    /// </summary>
    public class UserFilterRsp
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// 目前狀態
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 最後更改使用者
        /// </summary>
        public string LastModifier { get; set; }

        /// <summary>
        /// 最後更改資訊日期
        /// </summary>
        public DateTime? LastModifyDate { get; set; }

        /// <summary>
        /// 最後更改密碼日期
        /// </summary>
        public DateTime? LastChangePwdDate { get; set; }

        /// <summary>
        /// 最後登入日期
        /// </summary>
        public DateTime? LastLoginDate { get; set; }
    }
}
