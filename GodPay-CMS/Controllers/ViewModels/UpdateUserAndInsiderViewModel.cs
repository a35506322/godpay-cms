using System.ComponentModel.DataAnnotations;

namespace GodPay_CMS.Controllers.ViewModels
{
    /// <summary>
    /// User And Insider ViewModal
    /// </summary>
    public class UpdateUserAndInsiderViewModel
    {
        /// <summary>
        /// 流水號(PK)
        /// </summary>
        [Required]
        public int Uid { get; set; }

        /// <summary>
        /// 帳號
        /// </summary>
        [Required(ErrorMessage = "帳號為必填")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-zA-Z]).{6,20}$", ErrorMessage = "請至少輸入大小寫英文1位、1位數字1位及6-20位帳號")]
        public string UserId { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "{Email必填")]
        [EmailAddress(ErrorMessage = "請輸入正確Email格式")]
        public string Email { get; set; }

        /// <summary>
        /// 目前狀態
        /// </summary>
        [Required(ErrorMessage = "目前狀態為必填")]
        public string Status { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        [Required(ErrorMessage = "名子為必填")]
        public string Name { get; set; }

        /// <summary>
        /// 部門
        /// </summary>
        [Required(ErrorMessage = "部門為必填")]
        public string Department { get; set; }
    }
}
