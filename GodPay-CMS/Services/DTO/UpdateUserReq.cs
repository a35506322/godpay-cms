using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO
{
    public class UpdateUserReq
    {
        public string ModifierId { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
    }
}
