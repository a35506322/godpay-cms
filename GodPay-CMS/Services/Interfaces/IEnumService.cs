using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Interfaces
{
    public interface IEnumService
    {
        public ResponseViewModel GetRoleEnum();
        public ResponseViewModel GetAccountStatusEnum();
    }
}
