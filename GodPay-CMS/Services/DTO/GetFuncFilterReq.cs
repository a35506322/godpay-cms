using GodPay_CMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO
{
    public class GetFuncFilterReq
    {
        /// <summary>
        /// 角色
        /// </summary>
        public int Role { get; set; }
        /// <summary>
        /// 功能Flag
        /// </summary>
        public int FuncFlag { get; set; }
        /// <summary>
        /// 是否出現在網站
        /// </summary>
        public string IsWebSite { get; set; }
        /// <summary>
        /// 英文名子(controller)
        /// </summary>
        public string FuncClassEnName { get; set; }
    }
}
