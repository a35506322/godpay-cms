using System;

namespace GodPay_CMS.Repositories.Entity
{
    /// <summary>
    /// 特店詳細資訊
    /// </summary>
    public class Store
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
        public string StoreName { get; set; }

        /// <summary>
        /// 統一編號
        /// </summary>
        public string TaxId { get; set; }

        /// <summary>
        ///  負責人
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        ///  公司地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///  負責人電子信箱
        /// </summary>
        public string OwnerEmail { get; set; }

        /// <summary>
        /// 公司名稱
        /// </summary>
        public string CustomerName { get; set; }
    }
}
