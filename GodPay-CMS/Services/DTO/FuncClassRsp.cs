using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public string FuncClassCode { get; set; }

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
        public List<FuncRsp> FuncRsps { get; set; }
    }
}
