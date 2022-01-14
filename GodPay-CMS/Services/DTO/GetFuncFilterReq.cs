namespace GodPay_CMS.Services.DTO
{
    public class GetFuncFilterReq
    {
        /// <summary>
        /// 角色
        /// </summary>
        public int Role { get; set; }
        /// <summary>
        /// 功能Flag
        /// </summary>
        public long FuncFlag { get; set; }
        /// <summary>
        /// 是否出現在網站
        /// </summary>
        public string IsWebSite { get; set; } = string.Empty;
        /// <summary>
        /// 英文名字(controller)
        /// </summary>
        public string FuncClassEnName { get; set; } = string.Empty;
    }
}
