using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Entity
{
    /// <summary>
    /// 特店詳細資訊
    /// </summary>
    public class Store
    {
        /// <summary>
        /// 流水號(PK)
        /// </summary>
        public int Sid { get; set; }
        /// <summary>
        /// User PK(FK)
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 全名
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 別名
        /// </summary>
        public string ShortName { get; set; }
        public string StoreData1 { get; set; }
        public string StoreData2 { get; set; }
    }
}
