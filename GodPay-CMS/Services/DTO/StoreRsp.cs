using GodPay_CMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO
{
    public class StoreRsp
    {
        /// <summary>
        /// 流水號
        /// </summary>
        public int Sid{ get; set; }
        /// <summary>
        /// 特約商店代表ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 特約商店代表Eamil
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 目前狀態
        /// </summary>
        public AccountStatusEnum Status { get; set; }
        /// <summary>
        /// 特約商店全名
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 特約商店別名
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// 測試欄位1
        /// </summary>
        public string StoreData1 { get; set; }
        /// <summary>
        /// 測試欄位2
        /// </summary>
        public string StoreData2 { get; set; }
    }
}
