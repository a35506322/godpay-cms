using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GodPay_CMS.ViewComponents
{
    public class NavbarVertical : ViewComponent
    {
        private List<AuthorityViewModel> authorityViewModels { get; set; }
        private readonly IHttpContextAccessor _httpContextAccessor;
        public NavbarVertical(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            authorityViewModels = new List<AuthorityViewModel>();

            authorityViewModels.Add
            (
               new AuthorityViewModel()
               {
                   FuncClassEnName = "home",
                   FuncClassChName = "首頁",
                   Functions = new List<FunctionViewModel>()
                   {
                        new FunctionViewModel ()
                        {
                            FuncEnName ="index",
                            FuncChName ="控制台"
                        }
                   }
               }
            );

            authorityViewModels.Add
            (
                new AuthorityViewModel()
                {
                    FuncClassEnName = "profile",
                    FuncClassChName = "帳號管理",
                    Functions = new List<FunctionViewModel>()
                    {
                        new FunctionViewModel ()
                        {
                             FuncEnName ="edituser",
                             FuncChName ="編輯使用者"
                        },
                        new FunctionViewModel ()
                        {
                             FuncEnName ="changekey",
                             FuncChName ="變更密碼"
                        }
                    }
                }
            );

            authorityViewModels.Add
            (
                new AuthorityViewModel()
                {
                    FuncClassEnName = "system",
                    FuncClassChName = "系統功能設定",
                    Functions = new List<FunctionViewModel>()
                    {
                        new FunctionViewModel ()
                        {
                             FuncEnName ="functionsetting",
                             FuncChName ="功能設定"
                        }
                    }
                }
            );

        }

        public IViewComponentResult Invoke()
        {
            var role = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == ClaimTypes.Role).Value;
            if (role != RoleEnum.Admin.ToString())
            {
                return View("NavbarVertical", "權限不足");
            }
            else
            {
                return View("NavbarVertical", authorityViewModels);
            }
        }
    }
}
