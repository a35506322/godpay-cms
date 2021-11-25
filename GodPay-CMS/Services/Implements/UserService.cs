﻿using AutoMapper;
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
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = "查無使用者資料" };

            return new ResponseViewModel() { RtnData = userRsp };
        }

        public async Task<ResponseViewModel> UpdateUser(EditUserViewModel editUserViewModel)
        {
            var updateUserReq = _mapper.Map<UpdateUserReq>(editUserViewModel);

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
            return new ResponseViewModel() { RtnMessage="更新成功",RtnData = result };
        }

    }
}
