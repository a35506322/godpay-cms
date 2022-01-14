using System;

namespace GodPay_CMS.Repositories.Entity
{
    /// <summary>
    /// 使用者
    /// </summary>
    public class User
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
        public int Role { get; set; }
        /// <summary>
        /// 權限總數
        /// </summary>
        public long Func { get; set; }
        /// <summary>
        /// 目前狀態
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 創造時間
        /// </summary>
        public DateTime CreateDate { get; set; }
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
        /// <summary>
        /// 業務詳細資料
        /// </summary>
        public Insider Insider { get; set; }
        /// <summary>
        /// 特約商店詳細資料
        /// </summary>
        public Store Store { get; set; } 
        /// <summary>
        /// 特店人員詳細資料
        /// </summary>
        public Personnel Personnel { get; set; }
    }
}
