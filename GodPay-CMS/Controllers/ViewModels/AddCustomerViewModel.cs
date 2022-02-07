using System.ComponentModel.DataAnnotations;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class AddCustomerViewModel
    {
        /// <summary>
        /// 公司名稱
        /// </summary>
        [Required(ErrorMessage ="公司名稱為必填")]
        public string CustomerName { get; set; }
    }
}
