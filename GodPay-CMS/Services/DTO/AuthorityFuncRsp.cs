using GodPay_CMS.Common.Enums;

namespace GodPay_CMS.Services.DTO
{
    /// <summary>
    /// 功能(塞選)
    /// </summary>
    public class AuthorityFuncRsp
    {
        /// <summary>
        /// 流水號(PK)
        /// </summary>
        public int Fid { get; set; }
        /// <summary>
        /// 英文名字(action)
        /// </summary>
        public string FuncEnName { get; set; }
        /// <summary>
        /// 中文名字(action)
        /// </summary>
        public string FuncChName { get; set; }
        /// <summary>
        /// 功能代碼
        /// </summary>
        public long FuncCode { get; set; }
        /// <summary>
        /// Role Value 陣列
        /// </summary>
        public int[] RoleFlag { get; set; }
    }
}