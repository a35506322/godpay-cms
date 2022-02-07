using System.ComponentModel.DataAnnotations;

namespace GodPay_CMS.Controllers.ViewModels
{
    /// <summary>
    /// 登入ViewModel
    /// </summary>
    public class SigninViewModel
    {
        /// <summary>
        /// 帳號
        /// </summary>
        [Required(ErrorMessage ="帳號為必填")]
        public string UserId { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        [Required(ErrorMessage = "密碼為必填")]
        public string UserKey { get; set; }
    }
}
