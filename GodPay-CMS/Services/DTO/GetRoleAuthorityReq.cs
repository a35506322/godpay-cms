namespace GodPay_CMS.Services.DTO
{
    public class GetRoleAuthorityReq
    {
        /// <summary>
        /// 角色
        /// </summary>
        public int Role { get; set; }
        /// <summary>
        /// 功能Flag
        /// </summary>
        public long FuncFlag { get; set; }
    }
}
