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
        public string Email { get; set; }

        /// <summary>
        /// 目前狀態
        /// </summary>
        public AccountStatusEnum Status { get; set; }

        /// <summary>
        /// CustomerId
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// StoreId
        /// </summary>
        public Guid StoreId { get; set; }

        /// <summary>
        /// 特店名稱
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// 統一編號
        /// </summary>
        public string TaxId { get; set; }

        /// <summary>
        /// 負責人
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// 公司地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 負責人電子信箱
        /// </summary>
        public string OwnerEmail { get; set; }
    }
}
