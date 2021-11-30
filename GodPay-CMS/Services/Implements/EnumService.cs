using GodPay_CMS.Common.Enums;
using GodPay_CMS.Common.Helpers;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Implements
{
    public class EnumService: IEnumService
    {
        public ResponseViewModel GetAccountStatusEnum()
        {
            var results = EnumHelper.GetEnumList<AccountStatusEnum>();

            return new ResponseViewModel() { RtnData = results };
        }

        public ResponseViewModel GetRoleEnum()
        {
            var results = EnumHelper.GetEnumList<RoleEnum>();
            return new ResponseViewModel() { RtnData = results };
        }
    }
}
