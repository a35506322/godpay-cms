using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public string UserId { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        public string UserKey { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public int Role { get; set; }
        /// <summary>
        /// 權限總數
        /// </summary>
        public int Func { get; set; }
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
        public int? LastModifier { get; set; }
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
