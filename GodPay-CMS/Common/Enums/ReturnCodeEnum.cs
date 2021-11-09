using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Common.Enums
{
    /// <summary>
    /// 回傳Ajax狀態碼
    /// </summary>
    public enum ReturnCodeEnum
    {
        /// <summary>回應失敗</summary>
        [Description("失敗")]
        Fail = 0,

        /// <summary>回應成功</summary>
        [Description("成功")]
        Success = 1,
    }
}
