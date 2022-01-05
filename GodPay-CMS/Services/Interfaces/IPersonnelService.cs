using GodPay_CMS.Controllers.ViewModels;
using System.Threading.Tasks;

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
        /// <param name="postStorePersonnelViewModel"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> PostStorePersonnel(PostStorePersonnelViewModel postStorePersonnelViewModel);
        /// <summary>
        /// 修改特店人員
        /// </summary>
        /// <param name="updateStorePersonnelViewModel"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> UpdateStorePersonnel(UpdateStorePersonnelViewModel updateStorePersonnelViewModel);
    }
}
