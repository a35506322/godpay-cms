using System.ComponentModel.DataAnnotations;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class EditKeyViewModel
    {
        /// <summary>
        /// 使用者ID
        /// </summary>
        [Required(ErrorMessage = "使用者帳號為必填")]
        public string UserId { get; set; }

        /// <summary>
        /// 舊密碼
        /// </summary>
        [Required(ErrorMessage = "使用者密碼為必填")]
        public string OldKey { get; set; }

        /// <summary>
        /// 新密碼
        /// </summary>
        [Required(ErrorMessage = "新密碼為必填")]
        public string NewKey { get; set; }

        /// <summary>
        /// 確認密碼
        /// </summary>
        [Required(ErrorMessage = "確認新密碼為必填")]
        [Compare("NewKey", ErrorMessage = "與新密碼不符")]
        public string NewKey2 { get; set; }
    }
}
