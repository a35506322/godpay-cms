using GodPay.Domain.Enums;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Common.Helpers;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.Interfaces;

namespace GodPay_CMS.Services.Implements
{
    public class EnumService: IEnumService
    {
        public ResponseViewModel GetAccountStatusEnum()
        {
            var results = EnumHelper.GetEnumListByDescription<AccountStatusEnum>();

            return new ResponseViewModel() { RtnData = results };
        }

        public ResponseViewModel GetRoleEnum()
        {
            var results = EnumHelper.GetEnumListByDescription<RoleEnum>();
            return new ResponseViewModel() { RtnData = results };
        }

        public ResponseViewModel GetGLBDStatusCodeEnum()
        {
            var results = EnumHelper.GetEnumListByName<GLDBStatusCode>();
            return new ResponseViewModel() { RtnData = results };
        }
    }
}
