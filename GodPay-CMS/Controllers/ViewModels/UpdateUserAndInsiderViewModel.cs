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
        [Required]
        public string UserId { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// 目前狀態
        /// </summary>
        [Required]
        public string Status { get; set; }

        /// <summary>
        /// 名子
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
