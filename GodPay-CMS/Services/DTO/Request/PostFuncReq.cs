using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO.Request
{
    public class PostFuncReq
    {
        /// <summary>
        /// 功能類別代碼(FK)
        /// </summary>
        [Required(ErrorMessage = "功能類別代碼必填")]
        public string FuncClassCode { get; set; }

        /// <summary>
        /// 英文名字(action)
        /// </summary>
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "只能輸入英文與數字")]
        [Required(ErrorMessage = "英文名子為必填")]
        public string FuncEnName { get; set; }

        /// <summary>
        /// 中文名字(action)
        /// </summary>
        [RegularExpression(@"^[\u4e00-\u9fa5]*$", ErrorMessage = "只能輸入中文")]
        [Required(ErrorMessage = "中文名子為必填")]
        public string FuncChName { get; set; }

        /// <summary>
        /// 是否出現在網站
        /// </summary>
        [Required(ErrorMessage = "{0}為必填")]
        public bool IsWebSite { get; set; }
    }
}
