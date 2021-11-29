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
        /// <summary>帳號停用</summary>
        [Description("帳號停用")]
        Deactivate = 1,

        /// <summary>帳號尚未開通</summary>
        [Description("帳號尚未開通")]
        ToBeOpened = 2,

        /// <summary>帳號開通失敗</summary>
        [Description("帳號開通失敗")]
        FailedToOpened = 3,

        /// <summary>帳號啟用中</summary>
        [Description("帳號啟用中")]
        Activate = 11,
    }
}
