using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class UpdateStorePersonnelViewModel
    {
        /// <summary>
        /// 帳號
        /// </summary>
        [Required]
        public string UserId { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "請輸入Email")]
        [EmailAddress(ErrorMessage = "請輸入正確Email格式")]
        public string Email { get; set; }

        /// <summary>
        /// 目前狀態
        /// </summary>
        [Required(ErrorMessage = "目前狀態為必填")]
        public string Status { get; set; }
    }
}
