using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO.Response
{
    public class BankDetailRsp
    {
        /// <summary>
        /// 銀行代碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 銀行名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 銀行帳號位數
        /// </summary>
        public string AccounLength { get; set; }
        /// <summary>
        /// 銀行類別
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 銀行地區
        /// </summary>
        public string Area { get; set; }
    }
}
