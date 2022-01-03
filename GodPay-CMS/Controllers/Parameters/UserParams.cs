namespace GodPay_CMS.Controllers.Parameters
{
    /// <summary>
    /// Businessman Query
    /// </summary>
    public class UserParams
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public int Role { get; set; }

        /// <summary>
        /// 目前狀態
        /// </summary>
        public string Status { get; set; }
    }
}
