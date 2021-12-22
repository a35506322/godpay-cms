using System;

namespace GodPay_CMS.Repositories.Entity
{
    public class Personnel
    {
        public int SeqNo { get; set; }
        public int Uid { get; set; }
        public Guid StoreId { get; set; }
        public string PersonnelName { get; set; }
    }
}
