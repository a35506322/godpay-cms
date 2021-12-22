using GodPay_CMS.Common.Attributes;
using GodPay_CMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers.ViewModels
{
    /// <summary>
    /// User And Insider ViewModal
    /// </summary>
    public class PostUserAndInsiderViewModel
    {
        /// <summary>
        /// 帳號
        /// </summary>
        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-zA-Z]).{6,20}$",ErrorMessage = "請至少輸入大小寫英文1位、1位數字1位及6-20位帳號")]
        public string UserId { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 部門
        /// </summary>
        [Required]
        public string Department { get; set; }
    }
}
