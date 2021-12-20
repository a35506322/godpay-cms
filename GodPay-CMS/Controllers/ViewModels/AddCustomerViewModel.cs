using System.ComponentModel.DataAnnotations;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class AddCustomerViewModel
    {
        /// <summary>
        /// 公司名稱
        /// </summary>
        [Required]
        public string customerName { get; set; }
    }
}
