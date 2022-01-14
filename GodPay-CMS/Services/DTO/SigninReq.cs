namespace GodPay_CMS.Services.DTO
{
    public class SigninReq
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string UserId { get; set; } = string.Empty;
        /// <summary>
        /// 密碼
        /// </summary>
        public string UserKey { get; set; } = string.Empty;
    }
}
