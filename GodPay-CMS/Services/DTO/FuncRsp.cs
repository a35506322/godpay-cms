﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO
{
    public class FuncRsp
    {
        /// <summary>
        /// 流水號(PK)
        /// </summary>
        public int Fid { get; set; }
        /// <summary>
        /// 功能類別代碼(FK)
        /// </summary>
        public string FuncClassCode { get; set; }
        /// <summary>
        /// 功能代碼
        /// </summary>
        public string FuncCode { get; set; }
        /// <summary>
        /// 英文名子(action)
        /// </summary>
        public string FuncEnName { get; set; }
        /// <summary>
        /// 中文名子(action)
        /// </summary>
        public string FuncChName { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public int Role { get; set; }
        /// <summary>
        /// 功能類別(單筆)
        /// </summary>
        public FuncClassRsp FuncClassRsp { get; set; }


    }
}
