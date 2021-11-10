using GodPay_CMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers.ViewModels
{
    /// <summary>
    /// 回傳Ajax Model
    /// </summary>
    /// <typeparam name="T">回傳資料型態</typeparam>
    public class ResponseViewModel<T>
    {
        /// <summary>
        /// 回傳狀態碼
        /// </summary>
        public ReturnCodeEnum RtnCode { get; set; } = ReturnCodeEnum.Success;
        /// <summary>
        /// 回傳狀態訊息
        /// </summary>
        public string RtnMessage { get; set; } = "";
        /// <summary>
        /// 回傳狀態資料
        /// </summary>
        public T RtnData { get; set; } = default(T);
    }
}
