﻿using System;

namespace GodPay_CMS.Services.DTO
{
    public class PersonnelRsp
    {
        public int Uid { get; set; }
        public string UserId { get; set; }
        public string UserKey { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public long Func { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string LastModifier { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public DateTime? LastChangePwdDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public Guid StoreId { get; set; }
        public string PersonnelName { get; set; }
    }
}
