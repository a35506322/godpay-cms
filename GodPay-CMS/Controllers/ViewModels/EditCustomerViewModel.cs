using System.ComponentModel.DataAnnotations;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class EditCustomerViewModel
    {
        /// <summary>
        /// 流水號
        /// </summary>
        [Required]
        public int SeqNo { get; set; }

        /// <summary>
        /// 公司名稱
        /// </summary>
        [Required]
        public string CustomerName { get; set; }
    }
}
