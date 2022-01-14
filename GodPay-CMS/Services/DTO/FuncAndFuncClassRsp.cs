namespace GodPay_CMS.Services.DTO
{
    public class FuncAndFuncClassRsp
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
        /// 功能類別中文名字
        /// </summary>
        public string FuncClassChName { get; set; } = string.Empty;

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
        /// 是否出現在網站
        /// </summary>
        public bool IsWebSite { get; set; } = false;
    }
}
