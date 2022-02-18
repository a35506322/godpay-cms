using GodPay_CMS.Common.Enums;
using System;

namespace GodPay_CMS.Services.DTO
{
    public class StoreParticularsRsp
    {
        /// <summary>
        /// 流水號
        /// </summary>
        public int SeqNo { get; set; }

        /// <summary>
        /// 特約商店代表ID
        /// </summary>
        public int Uid { get; set; }

        /// <summary>
        /// 特約商店代表Eamil
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 目前狀態
        /// </summary>
        public AccountStatusEnum Status { get; set; }
        /// <summary>
        /// 公司名稱
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// StoreId
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
        /// 負責人電子信箱
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
