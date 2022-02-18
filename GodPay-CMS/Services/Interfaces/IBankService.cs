using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Interfaces
{
    public interface IBankService
    {
        public Task<ResponseViewModel> GetBankDetailById(string code);
    }
}
