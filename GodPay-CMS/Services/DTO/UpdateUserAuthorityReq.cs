using System;

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
        public long Func { get; set; }

        /// <summary>
        /// 最後更改使用者
        /// </summary>
        public string LastModifier { get; set; }

        /// <summary>
        /// 最後更改資訊日期
        /// </summary>
        public DateTime LastModifyDate { get; set; }
    }
}
