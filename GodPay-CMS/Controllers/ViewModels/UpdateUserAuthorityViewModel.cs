using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class UpdateUserAuthorityViewModel
    {
        // <summary>
        /// 流水號(PK)
        /// </summary>
        [Range(1, int.MaxValue)]
        public int Uid { get; set; }
        /// <summary>
        /// 權限總數
        /// </summary>
        [Range(0, long.MaxValue)]
        public Int64 Func { get; set; }
    }
}
