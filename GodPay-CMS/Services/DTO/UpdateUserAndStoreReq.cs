﻿using GodPay_CMS.Common.Enums;
using System;

namespace GodPay_CMS.Services.DTO
{
    public class UpdateUserAndStoreReq
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
        /// CustomerId
        /// </summary>
        public Guid CustomerId { get; set; }

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
    }
}
