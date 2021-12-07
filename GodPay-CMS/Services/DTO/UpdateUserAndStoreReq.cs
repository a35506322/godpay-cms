using GodPay_CMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO
{
    public class UpdateUserAndStoreReq
    {
        /// <summary>
        /// 流水號(PK)
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 目前狀態
        /// </summary>
        public AccountStatusEnum Status { get; set; }
        /// <summary>
        /// 最後更改使用者
        /// </summary>
        public string LastModifier { get; set; }
        /// <summary>
        /// 最後更改資訊日期
        /// </summary>
        public DateTime? LastModifyDate { get; set; }
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
