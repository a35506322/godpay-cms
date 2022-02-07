using System.ComponentModel;

namespace GodPay_CMS.Common.Enums
{
    /// <summary>
    /// 回傳Ajax狀態碼
    /// </summary>
    public enum ReturnCodeEnum
    {
        /// <summary>回應成功</summary>
        [Description("執行成功")]
        Ok = 200,

        /// <summary>驗證失敗(表單)</summary>
        [Description("驗證表單失敗")]
        AuthenticationFail = 401,

        /// <summary>登入失敗</summary>
        [Description("登入失敗")]
        LoginFail = 402,

        /// <summary>取得資料失敗</summary>
        [Description("取得資料失敗")]
        GetFail = 403,

        /// <summary>查無資料</summary>
        [Description("查無資料")]
        NotFound = 404,

        /// <summary>驗證失敗(商業邏輯)</summary>
        [Description("驗證商業邏輯失敗")]
        AuthenticationLogicFail = 405,

        /// <summary>執行失敗</summary>
        [Description("執行失敗")]
        ExecutionFail = 417,

        /// <summary>新密碼不可與舊密碼相同</summary>
        [Description("新密碼不可與舊密碼相同")]
        SameKeyFail = 423,

        /// <summary>已存在相同名稱</summary>
        [Description("已存在相同名稱")]
        SameNameFail = 424,

        /// <summary>呼叫Api失敗</summary>
        [Description("呼叫Api失敗")]
        CallApiFail = 430,

        /// <summary>程式內部錯誤</summary>
        [Description("程式內部錯誤")]
        InternalProgramError = 500,
    }
}
