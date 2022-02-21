using GodPay_CMS.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace GodPay_CMS.Services.DTO
{
    /// <summary>
    /// ser And Insider Request
    /// </summary>
    public class PutUserAndInsiderReq
    {
        /// <summary>
        /// 流水號(PK)
        /// </summary>
        [Required]
        public int Uid { get; set; }

        /// <summary>
        /// 帳號
        /// </summary>
        [Required(ErrorMessage = "帳號為必填")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-zA-Z]).{6,20}$", ErrorMessage = "請至少輸入大小寫英文1位、1位數字1位及6-20位帳號")]
        public string UserId { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "{Email必填")]
        [EmailAddress(ErrorMessage = "請輸入正確Email格式")]
        public string Email { get; set; }

        /// <summary>
        /// 目前狀態
        /// </summary>
        [Required(ErrorMessage = "目前狀態為必填")]
        public string Status { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        [Required(ErrorMessage = "名子為必填")]
        public string Name { get; set; }

        /// <summary>
        /// 部門
        /// </summary>
        [Required(ErrorMessage = "部門為必填")]
        public string Department { get; set; }

        /// <summary>
        /// 最後更改使用者
        /// </summary>
        public string LastModifier { get; set; } = string.Empty;
        /// <summary>
        /// 最後更改資訊日期
        /// </summary>
        public DateTime? LastModifyDate { get; set; }
    }
}
