using System.ComponentModel.DataAnnotations;

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
