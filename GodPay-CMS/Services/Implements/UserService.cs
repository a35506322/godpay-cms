using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Common.Helpers;
using GodPay_CMS.Common.Util;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.DTO;
using GodPay_CMS.Services.DTO.Request;
using GodPay_CMS.Services.DTO.Response;
using GodPay_CMS.Services.Interfaces;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepostioryWrapper _repostioryWrapper;

        public UserService(IRepostioryWrapper repostioryWrapper, IMapper mapper)
        {
            _repostioryWrapper = repostioryWrapper;
            _mapper = mapper;
        }

        public async Task<ResponseViewModel> GetUserByUserId(string userId)
        {
            var user = await _repostioryWrapper.userRepository.GetByUserId(userId);

            var userRsp = _mapper.Map<UserFilterRsp>(user);

            if (userRsp == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = ReturnCodeEnum.NotFound.GetEnumDescription() };

            return new ResponseViewModel() { RtnData = userRsp };
        }

        public async Task<ResponseViewModel> UpdateUser(PutUserReq putUserReq)
        {
            var user = _mapper.Map<User>(putUserReq);

            var modifier = await _repostioryWrapper.userRepository.GetByUserId(user.LastModifier);
            if (modifier == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.AuthenticationLogicFail, RtnMessage = ReturnCodeEnum.AuthenticationLogicFail.GetEnumDescription() };

            var target = await _repostioryWrapper.userRepository.GetByUserId(user.UserId);
            if (target == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = ReturnCodeEnum.NotFound.GetEnumDescription() };

            var count = await _repostioryWrapper.userRepository.UpdateUser(user);
            if (count == 0)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = ReturnCodeEnum.ExecutionFail.GetEnumDescription() };

            var result = await _repostioryWrapper.userRepository.GetByUserId(putUserReq.UserId);
            return new ResponseViewModel() {  RtnData = result };
        }

        public async Task<ResponseViewModel> UpdateKey(PutEditKeyReq putEditKeyReq)
        {
            var userReq = new User
            {
                UserId = putEditKeyReq.UserId,
                UserKey = putEditKeyReq.OldKey
            };
            var user = await _repostioryWrapper.userRepository.GetByUserIdAndUserKey(userReq);

            if (user == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = ReturnCodeEnum.NotFound.GetEnumDescription() };

            var newKey = RNGCrypto.HMACSHA256(putEditKeyReq.NewKey, putEditKeyReq.UserId);

            if (newKey == user.UserKey)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.SameKeyFail, RtnMessage = ReturnCodeEnum.SameKeyFail.GetEnumDescription() };

            int result = await _repostioryWrapper.userRepository.UpdateKey(putEditKeyReq);

            if (result == 0)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = ReturnCodeEnum.ExecutionFail.GetEnumDescription() };

            return new ResponseViewModel();
        }
    }
}
