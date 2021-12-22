using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class PostFuncViewModel
    {
        /// <summary>
        /// 功能類別代碼(FK)
        /// </summary>
        [Required]
        public string FuncClassCode { get; set; }

        /// <summary>
        /// 英文名字(action)
        /// </summary>
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "只能輸入英文與數字")]
        [Required]
        public string FuncEnName { get; set; }

        /// <summary>
        /// 中文名字(action)
        /// </summary>
        [RegularExpression(@"^[\u4e00-\u9fa5]*$", ErrorMessage = "只能輸入中文")]
        [Required]
        public string FuncChName { get; set; }

        /// <summary>
        /// 是否出現在網站
        /// </summary>
        [Required]
        public bool IsWebSite { get; set; }
    }
}
