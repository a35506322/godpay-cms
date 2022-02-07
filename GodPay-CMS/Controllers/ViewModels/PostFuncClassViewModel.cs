using System.ComponentModel.DataAnnotations;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class PostFuncClassViewModel
    {
        /// <summary>
        /// 英文名字(action)
        /// </summary>
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "只能輸入英文與數字")]
        [Required(ErrorMessage ="英文名子為必輸")]
        public string FuncClassEnName { get; set; }

        /// <summary>
        /// 中文名字(action)
        /// </summary>
        [RegularExpression(@"^[\u4e00-\u9fa5]*$", ErrorMessage = "只能輸入中文")]
        [Required(ErrorMessage = "中文名子為必輸")]
        public string FuncClassChName { get; set; }
    }
}
