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
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        [Required]
        public string UserKey { get; set; }
    }
}
