using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO.Request
{
    public class PutAuthorityFuncReq
    {
        /// <summary>
        /// 流水號(PK)
        /// </summary>
        [Required]
        public int Fid { get; set; }

        /// <summary>
        /// 英文名字(action)
        /// </summary>
        [Required(ErrorMessage = "英文名字(action)為必填")]
        public string FuncEnName { get; set; }

        /// <summary>
        /// 中文名字(action)
        /// </summary>
        [Required(ErrorMessage = "中文名字(action)為必填")]
        public string FuncChName { get; set; }

        /// <summary>
        /// 功能代碼
        /// </summary>
        [Required(ErrorMessage = "功能代碼為必填")]
        public long FuncCode { get; set; }

        /// <summary>
        /// Role Value 陣列
        /// </summary>
        [Required]
        public int[] RoleFlag { get; set; }
    }
}
