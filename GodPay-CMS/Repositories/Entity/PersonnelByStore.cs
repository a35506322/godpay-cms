using System;

namespace GodPay_CMS.Repositories.Entity
{
    public class PersonnelByStore
    {
        public int Uid { get; set; }
        public string UserId { get; set; }
        public string UserKey { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public long Func { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string LastModifier { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public DateTime? LastChangePwdDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public Guid StoreId { get; set; }
        public string PersonnelName { get; set; }
    }
}
