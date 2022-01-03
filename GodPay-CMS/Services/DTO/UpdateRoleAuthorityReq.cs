namespace GodPay_CMS.Services.DTO
{
    public class UpdateRoleAuthorityReq
    {
        /// <summary>
        /// 流水號(PK)
        /// </summary>
        public int Fid { get; set; }
        /// <summary>
        /// 功能代碼
        /// </summary>
        public long FuncCode { get; set; }
        /// <summary>
        /// Role Value
        /// </summary>
        public int RoleFlag { get; set; }
    }
}
