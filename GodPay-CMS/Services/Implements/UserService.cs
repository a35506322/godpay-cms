using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Interfaces;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Implements
{
    public class UserService
    {
        private readonly IRepostioryWrapper _repostioryWrapper;

        public UserService(IRepostioryWrapper repostioryWrapper)
        {
            _repostioryWrapper = repostioryWrapper;
        }

        public async Task<ResponseViewModel> GetUser(string userId)
        {
            var result = await _repostioryWrapper.userRepository.GetByUserId(userId);
            if (result == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = "查無使用者資料" };

            return new ResponseViewModel() { RtnData = result };
        }
    }
}
