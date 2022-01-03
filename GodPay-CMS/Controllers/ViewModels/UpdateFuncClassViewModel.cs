using System.ComponentModel.DataAnnotations;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class UpdateFuncClassViewModel
    {
        /// <summary>
        /// 功能類別代碼Code(PK)
        /// </summary>       
        public string FuncClassCode { get; set; }

        /// <summary>
        /// 英文名字(action)
        /// </summary>
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "只能輸入英文與數字")]
        [Required]
        public string FuncClassEnName { get; set; }

        /// <summary>
        /// 中文名字(action)
        /// </summary>
        [RegularExpression(@"^[\u4e00-\u9fa5]*$", ErrorMessage = "只能輸入中文")]
        [Required]
        public string FuncClassChName { get; set; }
    }
}
