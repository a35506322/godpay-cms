using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO
{
    public class UserReq
    {
        public int Uid { get; set; }
        public string UserId { get; set; }
        public string UserKey { get; set; }
        public int Role { get; set; }
        public int Func { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public int? LastModifier { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public DateTime? LastChangePwdDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
