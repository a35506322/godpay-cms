using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO
{
    public class GetRoleAuthorityReq
    {
        /// <summary>
        /// 角色
        /// </summary>
        public int Role { get; set; }
        /// <summary>
        /// 功能Flag
        /// </summary>
        public int FuncFlag { get; set; }
    }
}
