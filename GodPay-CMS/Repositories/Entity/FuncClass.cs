using GodPay_CMS.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Entity
{
    /// <summary>
    /// 功能類別
    /// </summary>
    public class FuncClass
    {
        /// <summary>
        /// 功能類別代碼Code(PK)
        /// </summary>
        public string FuncClassCode { get; set; }
        /// <summary>
        /// 英文名子(action)
        /// </summary>
        public string FuncClassEnName { get; set; }
        /// <summary>
        /// 中文名子(action)
        /// </summary>
        public string FuncClassChName { get; set; }
        /// <summary>
        /// 功能(多筆)
        /// </summary>
        public List<Func> Funcs { get; set; } = new List<Func>();
    }
}
