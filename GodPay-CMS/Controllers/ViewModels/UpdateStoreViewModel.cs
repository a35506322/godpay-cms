using System.ComponentModel.DataAnnotations;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class UpdateStoreViewModel
    {
        // <summary>
        /// 流水號(PK)
        /// </summary>
        [Required]
        public int Uid { get; set; }

        /// <summary>
        /// 特店名稱
        /// </summary>
        [Required(ErrorMessage = "特店名稱為必填")]
        public string StoreName { get; set; }

        /// <summary>
        /// 統一編號
        /// </summary>
        [Required(ErrorMessage = "統一編號為必填")]
        [StringLength(8, ErrorMessage = "統一編號長度為8碼")]
        public string TaxId { get; set; }

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
        [Required(ErrorMessage = "負責人電子信箱為必填")]
        [EmailAddress(ErrorMessage = "請輸入正確Email格式")]
        public string OwnerEmail { get; set; }
    }
}
