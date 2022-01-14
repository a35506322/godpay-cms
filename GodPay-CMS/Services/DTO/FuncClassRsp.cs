using System.Collections.Generic;

namespace GodPay_CMS.Services.DTO
{
    /// <summary>
    /// 功能類別
    /// </summary>
    public class FuncClassRsp
    {
        /// <summary>
        /// 功能類別代碼Code(PK)
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
        public List<FuncRsp> FuncRsps { get; set; }
    }
}
