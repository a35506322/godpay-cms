using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO
{
    /// <summary>
    /// 特店詳細資料(塞選)
    /// </summary>
    public class StoreFilterRsp
    {
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
