using System;

namespace GodPay_CMS.Services.DTO
{
    /// <summary>
    /// 使用者(Response)
    /// </summary>
    public class UserFilterRsp
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
        /// 角色
        /// </summary>
        public string Role { get; set; } = string.Empty;

        /// <summary>
        /// 角色(中文名稱)
        /// </summary>
        public string RoleChName { get; set; } = string.Empty;

        /// <summary>
        /// 權限旗標
        /// </summary>
        public long Func { get; set; }

        /// <summary>
        /// 目前狀態
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// 目前狀態(中文名稱)
        /// </summary>
        public string StatusChName { get; set; } = string.Empty;

        /// <summary>
        /// 最後更改使用者
        /// </summary>
        public string LastModifier { get; set; } = string.Empty;

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
