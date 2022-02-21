using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO.Response
{
    public class StoreDDLRsp
    {

        /// <summary>
        /// StoreId
        /// </summary>
        public Guid StoreId { get; set; }

        /// <summary>
        /// 特店名稱
        /// </summary>
        public string StoreName { get; set; } = string.Empty;
    }
}
