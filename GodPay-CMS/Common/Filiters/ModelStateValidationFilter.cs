using GodPay_CMS.Common.Enums;
using GodPay_CMS.Common.Helpers;
using GodPay_CMS.Controllers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GodPay_CMS.Common.Filiters
{
    public class ModelStateValidationFilter : IActionFilter
    {
        // Action 執行前
        public void OnActionExecuting(ActionExecutingContext context)
        {
            ResponseViewModel<string> responseViewModel = new ResponseViewModel<string>();
            if (!context.ModelState.IsValid)
            {
                responseViewModel.RtnCode = ReturnCodeEnum.AuthenticationFail;
                responseViewModel.RtnMessage = "Server驗證失敗";
                responseViewModel.RtnData = context.ModelState.GetModelStateHelper();
                context.Result = new OkObjectResult(responseViewModel);
            }
        }

        // Action 執行後
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

    }
}
