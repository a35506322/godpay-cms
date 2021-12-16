using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Interfaces
{
    /// <summary>
    /// 權限伺服器
    /// </summary>
    public interface IAuthorityService
    {
        /// <summary>
        /// 功能列表(角色塞選)
        /// </summary>
        /// <returns></returns>
        public Task<ResponseViewModel> GetListOfFunctions();

        /// <summary>
        /// 功能列表(角色塞選)(進階塞選)
        /// </summary>
        /// <returns></returns>
        public Task<ResponseViewModel> GetListOfFunctionsFilter(FunctionParams functionParams);

        /// <summary>
        /// 修改角色最大權限
        /// </summary>
        /// <param name="updateAuthorityClassViewModels"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> UpdateRoleMaxAuthority(IEnumerable<UpdateAuthorityClassViewModel> updateAuthorityClassViewModels);
       
        /// <summary>
        /// 功能類別列表
        /// </summary>
        /// <returns></returns>
        public Task<ResponseViewModel> GetListOfFuncClass();

        /// <summary>
        /// 新增功能類別
        /// </summary>
        /// <param name="postFuncClassViewModel"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> PostFuncClass(PostFuncClassViewModel postFuncClassViewModel);

        /// <summary>
        /// 個別功能類別
        /// </summary>
        /// <param name="funcCode"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> GetFuncClassDetailById(string funcCode);

        /// <summary>
        /// 編輯功能類別
        /// </summary>
        /// <param name="updateFuncClassViewModel"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> UpdateFuncClass(UpdateFuncClassViewModel updateFuncClassViewModel);
    }
}
