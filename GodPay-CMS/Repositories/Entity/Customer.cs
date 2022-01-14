using System;

namespace GodPay_CMS.Repositories.Entity
{
    public class Customer
    {
        /// <summary>
        /// 流水號(PK)
        /// </summary>
        public int SeqNo { get; set; }

        /// <summary>
        /// CustomerId
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// 公司名稱
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <string>
        /// SecretKey
        /// </summary>
        public string SecretKey { get; set; } = string.Empty;
    }
}
