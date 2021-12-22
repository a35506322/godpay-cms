using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO
{
    /// <summary>
    /// 功能類別(塞選)
    /// </summary>
    public class AuthorityFuncClassRsp
    {
        /// <summary>
        /// 英文名字(controller)
        /// </summary>
        public string FuncClassEnName { get; set; }
        /// <summary>
        /// 中文名字(controller)
        /// </summary>
        public string FuncClassChName { get; set; }
        /// <summary>
        /// 功能(多筆)
        /// </summary>
        public IEnumerable<AuthorityFuncRsp> Functions { get; set; }
    }
}
