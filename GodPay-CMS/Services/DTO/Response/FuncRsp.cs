namespace GodPay_CMS.Services.DTO.Response
{
    /// <summary>
    /// 功能
    /// </summary>
    public class FuncRsp
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
        public int Role { get; set; }

        /// <summary>
        /// 是否出現在網站
        /// </summary>
        public bool IsWebSite { get; set; }

        /// <summary>
        /// 功能類別(單筆)
        /// </summary>
        public FuncClassRsp FuncClassRsp { get; set; }
    }
}
