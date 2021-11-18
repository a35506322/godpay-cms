using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Interfaces
{
    public interface IFuncRepository : IGenericRepository<FuncRsp>, IGenericRepositoryById<FuncRsp, int>
    {

        public Task<IEnumerable<FuncRsp>> GetByFuncClassAndFunc();
    }
}
