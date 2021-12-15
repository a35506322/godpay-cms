namespace GodPay_CMS.Services.DTO
{
    /// <summary>
    /// 特店詳細資料(篩選)
    /// </summary>
    public class StoreFilterRsp
    {
        /// <summary>
        /// User PK(FK)
        /// </summary>
        public int Uid { get; set; }

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
    }
}
