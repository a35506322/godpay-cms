using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Interfaces
{
    public interface IAuthorityService
    {
        public Task<ResponseViewModel> GetListOfFunctions();
    }
}
