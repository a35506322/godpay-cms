using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO.Response;
using GodPay_CMS.Services.DTO.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Interfaces
{
    public interface IFuncClassRepository : IGenericRepository<FuncClass>, IGenericRepositoryById<FuncClass, string>
    {
        /// <summary>
        /// 取得功能列表(1對多)
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<FuncClass>> GetAllByFuncClassAndFunc();
        /// <summary>
        /// 取得功能列表(1對多)(塞選)
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<FuncClass>> GetByFuncClassAndFuncFilter(GetByFuncClassAndFuncFilterReq getFuncFilterReq);
        /// <summary>
        /// 取得角色權限(包含是否有權限)
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<UserAuthorityFuncClassRsp>> GetRoleAuthority(GetRoleAuthorityReq getRoleAuthorityReq);
    }
}
