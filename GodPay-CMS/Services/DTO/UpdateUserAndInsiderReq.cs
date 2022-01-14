using GodPay_CMS.Common.Enums;
using System;

namespace GodPay_CMS.Services.DTO
{
    /// <summary>
    /// ser And Insider Request
    /// </summary>
    public class UpdateUserAndInsiderReq
    {
        /// <summary>
        /// 流水號(PK)
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        public string UserId { get; set; } = string.Empty;
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 目前狀態
        /// </summary>
        public AccountStatusEnum Status { get; set; }
        /// <summary>
        /// 最後更改使用者
        /// </summary>
        public string LastModifier { get; set; } = string.Empty;
        /// <summary>
        /// 最後更改資訊日期
        /// </summary>
        public DateTime? LastModifyDate { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 部門
        /// </summary>
        public string Department { get; set; } = string.Empty;
    }
}
