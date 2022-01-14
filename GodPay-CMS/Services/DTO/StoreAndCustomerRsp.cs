﻿using System;

namespace GodPay_CMS.Services.DTO
{
    public class StoreAndCustomerRsp
    {
        /// <summary>
        /// 流水號(PK)
        /// </summary>
        public int SeqNo { get; set; }

        /// <summary>
        /// User PK(FK)
        /// </summary>
        public int Uid { get; set; }

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
        ///  負責人
        /// </summary>
        public string Owner { get; set; } = string.Empty;

        /// <summary>
        ///  公司地址
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        ///  負責人電子信箱
        /// </summary>
        public string OwnerEmail { get; set; } = string.Empty;

        /// <summary>
        /// 風險等級
        /// </summary>
        public string Risk { get; set; } = string.Empty;

        /// <summary>
        /// 限制額度
        /// </summary>
        public decimal? TransLimit { get; set; }

        /// <summary>
        /// 公司名稱
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;
    }
}
