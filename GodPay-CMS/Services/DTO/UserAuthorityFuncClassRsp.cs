﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO
{
    public class UserAuthorityFuncClassRsp
    {
        /// <summary>
        /// 功能類別代碼Code(PK)
        /// </summary>
        public string FuncClassCode { get; set; }
        /// <summary>
        /// 英文名字(action)
        /// </summary>
        public string FuncClassEnName { get; set; }
        /// <summary>
        /// 中文名字(action)
        /// </summary>
        public string FuncClassChName { get; set; }
        /// <summary>
        /// 功能(List)
        /// </summary>
        public List<UserAuthorityFuncRsp> UserAuthorityFuncRsps { get; set; } = new List<UserAuthorityFuncRsp>();

    }
}