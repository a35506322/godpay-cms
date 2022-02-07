using System.ComponentModel.DataAnnotations;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class EditUserViewModel
    {
        /// <summary>
        /// 修改人ID
        /// </summary>
        [Required(ErrorMessage = "修改者為必填")]
        public string ModifierId { get; set; }

        /// <summary>
        /// 使用者ID
        /// </summary>
        [Required(ErrorMessage = "帳號為必填")]
        public string UserId { get; set; }

        /// <summary>
        /// 電子信箱
        /// </summary>
        [Required(ErrorMessage = "{0}為必填")]
        [EmailAddress(ErrorMessage = "{0}格式不正確")]
        public string Email { get; set; }
    }
}
