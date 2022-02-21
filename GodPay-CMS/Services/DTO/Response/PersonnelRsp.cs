using System;

namespace GodPay_CMS.Services.DTO.Response
{
    public class PersonnelRsp
    {
        public int Uid { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string UserKey { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public long Func { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public string LastModifier { get; set; } = string.Empty;
        public DateTime? LastModifyDate { get; set; }
        public DateTime? LastChangePwdDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public Guid StoreId { get; set; }
        public string PersonnelName { get; set; } = string.Empty;
    }
}
