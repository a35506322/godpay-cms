namespace GodPay_CMS.Services.DTO
{
    public class UpdateUserAuthorityReq
    {
        // <summary>
        /// 流水號(PK)
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 權限總數
        /// </summary>
        public long Func { get; set; }
    }
}
