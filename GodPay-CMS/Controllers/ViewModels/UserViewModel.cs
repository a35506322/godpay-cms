using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string UserId { get; set; }
        public string UserKey { get; set; }
    }
}
