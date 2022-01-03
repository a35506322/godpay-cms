using System.ComponentModel.DataAnnotations;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class UpdateUserAndStoreViewModel
    {
        // <summary>
        /// 流水號(PK)
        /// </summary>
        [Required]
        public int Uid { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// 目前狀態
        /// </summary>
        [Required]
        public string Status { get; set; }

        /// <summary>
        /// CustomerId
        /// </summary>
        [Required]
        public string CustomerId { get; set; }

        /// <summary>
        /// 特店名稱
        /// </summary>
        [Required]
        public string StoreName { get; set; }

        /// <summary>
        /// 統一編號
        /// </summary>
        [Required]
        [StringLength(8)]
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
        ///  負責人電子信箱
        /// </summary>
        [Required]
        [EmailAddress]
        public string OwnerEmail { get; set; }
    }
}
