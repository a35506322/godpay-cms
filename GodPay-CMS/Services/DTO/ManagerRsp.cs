using GodPay_CMS.Common.Enums;

namespace GodPay_CMS.Services.DTO
{
    /// <summary>
    /// 業務篩選資料
    /// </summary>
    public class ManagerRsp
    {
        /// <summary>
        /// 流水號(PK)
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 目前狀態
        /// </summary>
        public AccountStatusEnum Status { get; set; }
        /// <summary>
        /// 名子
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 部門
        /// </summary>
        public string Department { get; set; }
    }
}
