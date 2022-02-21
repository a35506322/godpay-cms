using System.ComponentModel.DataAnnotations;

namespace GodPay_CMS.Services.DTO.Request
{
    /// <summary>
    /// 修改User DTO
    /// </summary>
    public class PutUserReq
    {
        /// <summary>
        /// 修改人ID
        /// </summary>
        [Required(ErrorMessage = "修改者為必填")]
        public string LastModifier { get; set; }

        /// <summary>
        /// 使用者ID
        /// </summary>
        [Required(ErrorMessage = "帳號為必填")]
        public string UserId { get; set; }

        /// <summary>
        /// 電子信箱
        /// </summary>
        [Required(ErrorMessage = "{0}為必填")]
        [EmailAddress(ErrorMessage = "{0}格式不正確")]
        public string Email { get; set; }
    }
}
