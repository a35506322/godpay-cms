using System;
using System.ComponentModel.DataAnnotations;

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
        public long Func { get; set; }
    }
}
