using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Interfaces
{
    public interface IFuncRepository : IGenericRepository<Func>, IGenericRepositoryById<Func, int>
    {
        /// <summary>
        /// 取得功能列表(1對1)
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Func>> GetByFuncClassAndFunc();

        /// <summary>
        /// 批次修改RoleFlag
        /// </summary>
        /// <param name="updateRoleAuthorityReqs"></param>
        /// <returns></returns>
        public Task<bool> BatchUpdateRoleFlag(IEnumerable<UpdateRoleAuthorityReq> updateRoleAuthorityReqs);
    }
}
