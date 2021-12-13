using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO
{
    public class UpdateUserAuthorityReq
    {
        // <summary>
        /// 流水號(PK)
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 權限總數
        /// </summary>
        public Int64 Func { get; set; }
    }
}
