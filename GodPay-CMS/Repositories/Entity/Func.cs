namespace GodPay_CMS.Repositories.Entity
{
    /// <summary>
    /// 功能
    /// </summary>
    public class Func
    {
        /// <summary>
        /// 流水號(PK)
        /// </summary>
        public int Fid { get; set; }

        /// <summary>
        /// 功能類別代碼(FK)
        /// </summary>
        public string FuncClassCode { get; set; } = string.Empty;

        /// <summary>
        /// 功能代碼
        /// </summary>
        public long FuncCode { get; set; }

        /// <summary>
        /// 英文名字(action)
        /// </summary>
        public string FuncEnName { get; set; } = string.Empty;

        /// <summary>
        /// 中文名字(action)
        /// </summary>
        public string FuncChName { get; set; } = string.Empty;

        /// <summary>
        /// 角色
        /// </summary>
        public int RoleFlag { get; set; }

        /// <summary>
        /// 是否出現在網站
        /// </summary>
        public bool IsWebSite { get; set; } = false;

        /// <summary>
        /// 功能類別(單筆)
        /// </summary>
        public FuncClass FuncClass { get; set; }
    }
}
