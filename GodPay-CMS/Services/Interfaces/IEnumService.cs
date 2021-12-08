using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Interfaces
{
    public interface IEnumService
    {
        /// <summary>
        /// 取得角色
        /// </summary>
        /// <returns></returns>
        public ResponseViewModel GetRoleEnum();
        /// <summary>
        /// 取得帳號狀態
        /// </summary>
        /// <returns></returns>
        public ResponseViewModel GetAccountStatusEnum();
    }
}
