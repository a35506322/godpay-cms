using System.ComponentModel.DataAnnotations;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class PostFuncClassViewModel
    {
        /// <summary>
        /// 英文名字(action)
        /// </summary>
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "只能輸入英文與數字")]
        [Required]
        public string FuncClassEnName { get; set; }

        /// <summary>
        /// 中文名字(action)
        /// </summary>
        [Required]
        public string FuncClassChName { get; set; }
    }
}
