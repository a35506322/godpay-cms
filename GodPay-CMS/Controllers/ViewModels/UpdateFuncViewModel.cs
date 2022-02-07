using System.ComponentModel.DataAnnotations;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class UpdateFuncViewModel
    {
        /// <summary>
        /// 流水號(PK)
        /// </summary>
        [Required]
        public int Fid { get; set; }

        /// <summary>
        /// 功能類別代碼(FK)
        /// </summary>
        [Required(ErrorMessage = "功能類別代碼")]
        public string FuncClassCode { get; set; }

        /// <summary>
        /// 英文名字(action)
        /// </summary>
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "只能輸入英文與數字")]
        [Required(ErrorMessage = "英文名字(action)為必填")]
        public string FuncEnName { get; set; }

        /// <summary>
        /// 中文名字(action)
        /// </summary>
        [RegularExpression(@"^[\u4e00-\u9fa5]*$", ErrorMessage = "只能輸入中文")]
        [Required(ErrorMessage = "中文名字(action)為必填")]
        public string FuncChName { get; set; }

        /// <summary>
        /// 是否出現在網站
        /// </summary>
        [Required]
        public bool IsWebSite { get; set; }
    }
}
