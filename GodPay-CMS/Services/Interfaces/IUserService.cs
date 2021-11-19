using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.DTO;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Interfaces
{
    public interface IUserService
    {
        public Task<ResponseViewModel> GetUser(string userId);
        public Task<ResponseViewModel> UpdateUser(UpdateUserReq updateUserReq);
    }
}
