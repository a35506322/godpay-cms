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
        /// <summary>回應成功</summary>
        [Description("成功")]
        Ok = 200,

        /// <summary>驗證失敗</summary>
        [Description("驗證失敗")]
        AuthenticationFail = 401,

        /// <summary>登入失敗</summary>
        [Description("登入失敗")]
        LoginFail = 402,
    }
}
