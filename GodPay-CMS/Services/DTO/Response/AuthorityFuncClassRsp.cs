using System.Collections.Generic;

namespace GodPay_CMS.Services.DTO.Response
{
    /// <summary>
    /// 功能類別(塞選)
    /// </summary>
    public class AuthorityFuncClassRsp
    {
        /// <summary>
        /// PK
        /// </summary>
        public string FuncClassCode { get; set; } = string.Empty;
        /// <summary>
        /// 英文名字(controller)
        /// </summary>
        public string FuncClassEnName { get; set; } = string.Empty;
        /// <summary>
        /// 中文名字(controller)
        /// </summary>
        public string FuncClassChName { get; set; } = string.Empty;
        /// <summary>
        /// 功能(多筆)
        /// </summary>
        public IEnumerable<AuthorityFuncRsp> Functions { get; set; }
    }
}
