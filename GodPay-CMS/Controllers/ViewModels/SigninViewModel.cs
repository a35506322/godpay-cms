using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
