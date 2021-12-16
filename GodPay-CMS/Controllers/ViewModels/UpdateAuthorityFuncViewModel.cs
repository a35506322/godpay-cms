using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers.ViewModels
{
    /// <summary>
    /// 修改功能 View Model
    /// </summary>
    public class UpdateAuthorityFuncViewModel
    {
        /// <summary>
        /// 流水號(PK)
        /// </summary>
        [Required]
        public int Fid { get; set; }
        /// <summary>
        /// 英文名子(action)
        /// </summary>
        [Required]
        public string FuncEnName { get; set; }
        /// <summary>
        /// 中文名子(action)
        /// </summary>
        [Required]
        public string FuncChName { get; set; }
        /// <summary>
        /// 功能代碼
        /// </summary>
        [Required]
        public long FuncCode { get; set; }
        /// <summary>
        /// Role Value 陣列
        /// </summary>
        [Required]
        public int[] RoleFlag { get; set; }
    }
}
