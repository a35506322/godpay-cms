using System.Collections.Generic;

namespace GodPay_CMS.Services.DTO
{
    public class UserAuthorityFuncClassRsp
    {
        /// <summary>
        /// 功能類別代碼Code(PK)
        /// </summary>
        public string FuncClassCode { get; set; } = string.Empty;
        /// <summary>
        /// 英文名字(action)
        /// </summary>
        public string FuncClassEnName { get; set; } = string.Empty;
        /// <summary>
        /// 中文名字(action)
        /// </summary>
        public string FuncClassChName { get; set; } = string.Empty;
        /// <summary>
        /// 功能(List)
        /// </summary>
        public List<UserAuthorityFuncRsp> UserAuthorityFuncRsps { get; set; }

    }
}
