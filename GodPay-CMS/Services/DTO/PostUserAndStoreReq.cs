using GodPay_CMS.Common.Enums;
using System;

namespace GodPay_CMS.Services.DTO
{
    /// <summary>
    /// User And Store Request
    /// </summary>
    public class PostUserAndStoreReq
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
        /// 公司Id
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// 特店Id
        /// </summary>
        public Guid StoreId { get; set; }

        /// <summary>
        /// 特店名稱
        /// </summary>
        public string StoreName { get; set; } = string.Empty;

        /// <summary>
        /// 統一編號
        /// </summary>
        public string TaxId { get; set; } = string.Empty;

        /// <summary>
        /// 負責人
        /// </summary>        
        public string Owner { get; set; } = string.Empty;

        /// <summary>
        /// 公司地址
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        ///  負責人電子信箱
        /// </summary>
        public string OwnerEmail { get; set; } = string.Empty;

        /// <summary>
        /// 收款銀行帳號
        /// </summary>
        public string ReceivingAccount { get; set; } = string.Empty;

        /// <summary>
        /// 收款銀行代碼
        /// </summary>
        public string ReceivingBankCode { get; set; } = string.Empty;

        /// <summary>
        /// 收款銀行分行
        /// </summary>
        public string ReceivingBranch { get; set; } = string.Empty;

        /// <summary>
        /// 匯款天數
        /// </summary>
        public int MoneyTransferDay { get; set; }
    }
}
