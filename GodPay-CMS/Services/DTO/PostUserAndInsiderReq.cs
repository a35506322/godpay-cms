using GodPay_CMS.Common.Enums;
using System;

namespace GodPay_CMS.Services.DTO
{
    /// <summary>
    /// User And Insider Request
    /// </summary>
    public class PostUserAndInsiderReq
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// 密碼
        /// </summary>
        public string UserKey { get; set; } = string.Empty;

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 角色
        /// </summary>
        public RoleEnum Role { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        public int Func { get; set; }

        /// <summary>
        /// 目前狀態
        /// </summary>
        public AccountStatusEnum Status { get; set; }

        /// <summary>
        /// 創造時間
        /// </summary>
        public DateTime CreateDate { get; set; }

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
