using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.DTO;
using GodPay_CMS.Services.Interfaces;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Implements
{
    public class UserService : IUserService
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

        public async Task<ResponseViewModel> UpdateUser(UpdateUserReq updateUserReq)
        {
            var modifier = await _repostioryWrapper.userRepository.GetByUserId(updateUserReq.ModifierId);
            if (modifier == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.AuthenticationFail, RtnMessage = "驗證錯誤" };

            var target = await _repostioryWrapper.userRepository.GetByUserId(updateUserReq.UserId);
            if (target == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = "查無使用者資料" };

            var count = await _repostioryWrapper.userRepository.UpdateUser(updateUserReq);
            if (count == 0)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "變更使用者資料失敗" };

            var result = await _repostioryWrapper.userRepository.GetByUserId(updateUserReq.UserId);
            return new ResponseViewModel() { RtnData = result };
        }
    }
}
