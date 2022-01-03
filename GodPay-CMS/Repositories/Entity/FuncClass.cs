using System.Collections.Generic;

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
        /// 英文名字(action)
        /// </summary>
        public string FuncClassEnName { get; set; }

        /// <summary>
        /// 中文名字(action)
        /// </summary>
        public string FuncClassChName { get; set; }

        /// <summary>
        /// 功能(多筆)
        /// </summary>
        public List<Func> Funcs { get; set; } = new List<Func>();
    }
}
