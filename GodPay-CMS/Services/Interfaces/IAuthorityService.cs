using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.DTO.Request;
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
        public Task<ResponseViewModel> GetListOfFunctionsForAuthority();

        /// <summary>
        /// 功能列表(角色塞選)(進階塞選)
        /// </summary>
        /// <returns></returns>
        public Task<ResponseViewModel> GetListOfFunctionsFilter(FunctionParams functionParams);

        /// <summary>
        /// 修改角色最大權限
        /// </summary>
        /// <param name="putAuthorityClassReq">putAuthorityClassReq</param>
        /// <returns></returns>
        public Task<ResponseViewModel> UpdateRoleMaxAuthority(IEnumerable<PutAuthorityClassReq> putAuthorityClassReq);
       
        /// <summary>
        /// 功能類別列表
        /// </summary>
        /// <returns></returns>
        public Task<ResponseViewModel> GetListOfFuncClass();

        /// <summary>
        /// 新增功能類別
        /// </summary>
        /// <param name="postFuncClassReq">postFuncClassReq</param>
        /// <returns></returns>
        public Task<ResponseViewModel> PostFuncClass(PostFuncClassReq postFuncClassReq);

        /// <summary>
        /// 個別功能類別
        /// </summary>
        /// <param name="funcCode"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> GetFuncClassDetailById(string funcCode);

        /// <summary>
        /// 編輯功能類別
        /// </summary>
        /// <param name="putFuncClassReq">putFuncClassReq</param>
        /// <returns></returns>
        public Task<ResponseViewModel> UpdateFuncClass(PutFuncClassReq putFuncClassReq);

        /// <summary>
        /// 取得功能總表
        /// </summary>
        /// <returns></returns>
        public Task<ResponseViewModel> GetListOfFunc();

        /// <summary>
        /// 取得個別功能資料
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> GetFuncDetailById(int fid);

        /// <summary>
        /// 修改功能
        /// </summary>
        /// <param name="putFuncReq">putFuncReq</param>
        /// <returns></returns>
        public Task<ResponseViewModel> UpdateFunc(PutFuncReq putFuncReq);

        /// <summary>
        /// 新增功能
        /// </summary>
        /// <param name="postFuncReq"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> PostFunc(PostFuncReq postFuncReq);

    }
}
