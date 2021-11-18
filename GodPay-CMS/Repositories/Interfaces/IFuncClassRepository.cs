using GodPay_CMS.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Interfaces
{
    public interface IFuncClassRepository : IGenericRepository<FuncClassRsp>, IGenericRepositoryById<FuncClassRsp, string>
    {
        public Task<IEnumerable<FuncClassRsp>> GetByFuncClassAndFunc();
    }
}
