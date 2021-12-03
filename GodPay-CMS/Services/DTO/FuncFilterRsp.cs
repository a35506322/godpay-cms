using GodPay_CMS.Common.Enums;

namespace GodPay_CMS.Services.DTO
{
    /// <summary>
    /// 功能(塞選)
    /// </summary>
    public class FuncFilterRsp
    {
        /// <summary>
        /// 英文名子(action)
        /// </summary>
        public string FuncEnName { get; set; }
        /// <summary>
        /// 中文名子(action)
        /// </summary>
        public string FuncChName { get; set; }

        public int[] RoleFlag { get; set; }
    }
}