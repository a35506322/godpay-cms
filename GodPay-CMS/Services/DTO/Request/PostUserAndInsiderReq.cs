using GodPay_CMS.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace GodPay_CMS.Services.DTO.Request
{
    /// <summary>
    /// User And Insider Request
    /// </summary>
    public class PostUserAndInsiderReq
    {
        /// <summary>
        /// 帳號
        /// </summary>
        [Required(ErrorMessage = "帳號為必填")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-zA-Z]).{6,20}$", ErrorMessage = "請至少輸入大小寫英文1位、1位數字1位及6-20位帳號")]
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "{Email必填")]
        [EmailAddress(ErrorMessage = "請輸入正確Email格式")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 名字
        /// </summary>
        [Required(ErrorMessage = "名子為必填")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 部門
        /// </summary>
        [Required(ErrorMessage = "部門為必填")]
        public string Department { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        public string UserKey { get; set; } = string.Empty;

        /// <summary>
        /// 角色
        /// </summary>
        public RoleEnum Role { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        public int Func { get; set; }

        /// <summary>
        /// 目前狀態
        /// </summary>
        public AccountStatusEnum Status { get; set; }

        /// <summary>
        /// 創造時間
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
