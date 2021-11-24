using System.ComponentModel.DataAnnotations;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class EditUserViewModel
    {
        [Required]
        public string ModifierId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required(ErrorMessage = "{0}為必填")]
        [EmailAddress(ErrorMessage = "{0}格式不正確")]
        public string Email { get; set; }
    }
}
