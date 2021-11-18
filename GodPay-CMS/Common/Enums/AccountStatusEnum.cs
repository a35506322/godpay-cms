using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Common.Enums
{
    /// <summary>
    /// 帳號狀態代碼
    /// </summary>
    public enum AccountStatusEnum
    {
        /// <summary>帳號驗證成功</summary>
        [Description("帳號啟用成功")]
        AccountSuccess = 1,

        /// <summary>帳號驗證失敗</summary>
        [Description("帳號驗證失敗")]
        AccountFail= 2,

        /// <summary>帳號註銷</summary>
        [Description("帳號註銷")]
        AccountLogout = 3,     
    }
}
