using GodPay_CMS.Controllers.ViewModels;
using System.Threading.Tasks;
using GodPay_CMS.Services.DTO.Request;

namespace GodPay_CMS.Services.Interfaces
{
    public interface IPersonnelService
    {
        /// <summary>
        /// 取得特店人員
        /// </summary>
        /// <returns></returns>
        public Task<ResponseViewModel> GetAllPersonnelByStore();
        /// <summary>
        /// 新增特店人員
        /// </summary>
        /// <param name="postStorePersonnelReq">postStorePersonnelReq</param>
        /// <returns></returns>
        public Task<ResponseViewModel> PostStorePersonnel(PostStorePersonnelReq postStorePersonnelReq);
        /// <summary>
        /// 修改特店人員
        /// </summary>
        /// <param name="putStorePersonnelReq">putStorePersonnelReq</param>
        /// <returns></returns>
        public Task<ResponseViewModel> UpdateStorePersonnel(PutStorePersonnelReq putStorePersonnelReq);
        /// <summary>
        /// 取得單筆特店人員權限
        /// </summary>
        /// <param name="userId">帳號</param>
        /// <returns></returns>
        public Task<ResponseViewModel> GetStorePersonnelAuthority(string userId);
        /// <summary>
        /// 修改特店人員權限
        /// </summary>
        /// <param name="putUserAuthorityReq">putUserAuthorityReq</param>
        /// <returns></returns>
        public Task<ResponseViewModel> UpdateStorePersonnelAuthority(PutUserAuthorityReq putUserAuthorityReq);
    }
}
