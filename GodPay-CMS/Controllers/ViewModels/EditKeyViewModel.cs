using System.ComponentModel.DataAnnotations;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class EditKeyViewModel
    {
        [Required(ErrorMessage = "使用者帳號為必填")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "使用者密碼為必填")]
        public string OldKey { get; set; }

        [Required(ErrorMessage = "新密碼為必填")]
        public string NewKey { get; set; }

        [Required(ErrorMessage = "確認新密碼為必填")]
        [Compare("NewKey", ErrorMessage = "與新密碼不符")]
        public string NewKey2 { get; set; }
    }
}
