using GodPay_CMS.Controllers.ViewModels;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Interfaces
{
    public interface IPersonnelService
    {
        public Task<ResponseViewModel> GetAllPersonnelByStore();
    }
}
