using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO
{
    public class CustomerReq
    {
        public Guid CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string SecretKey { get; set; }
    }
}
