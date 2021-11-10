using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class SigninViewModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string UserKey { get; set; }
    }
}
