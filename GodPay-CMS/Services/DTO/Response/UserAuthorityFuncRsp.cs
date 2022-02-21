﻿namespace GodPay_CMS.Services.DTO.Response
{
    public class UserAuthorityFuncRsp
    {
        /// <summary>
        /// 流水號(PK)
        /// </summary>
        public int Fid { get; set; }
        /// <summary>
        /// 功能代碼
        /// </summary>
        public long FuncCode { get; set; }
        /// <summary>
        /// 英文名字(action)
        /// </summary>
        public string FuncEnName { get; set; } = string.Empty;
        /// <summary>
        /// 中文名字(action)
        /// </summary>
        public string FuncChName { get; set; } = string.Empty;
        /// <summary>
        /// 是否有權限
        /// </summary>
        public bool IsAuthority { get; set; }
    }
}
