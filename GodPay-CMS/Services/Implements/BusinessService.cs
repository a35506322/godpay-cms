﻿using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Common.Util;
using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.DTO;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Implements
{
    public class BusinessService : IBusinessService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepostioryWrapper _repostioryWrapper;
        private readonly IMapper _mapper;
        public BusinessService(IRepostioryWrapper repostioryWrapper, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _repostioryWrapper = repostioryWrapper;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseViewModel> GetBusinessmenDeatil(int uid)
        {
            var insider = await _repostioryWrapper.insiderRepository.GetById(uid);

            if (insider == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = "查無業務詳細資料" };

            var insiderRsp = _mapper.Map<InsiderFilterRsp>(insider);

            return new ResponseViewModel() { RtnData = insiderRsp };
        }

        public async Task<ResponseViewModel> GetBusinessmens()
        {
            var users = await _repostioryWrapper.userRepository.GetByRole(RoleEnum.Manager);

            var userRsp = _mapper.Map<IEnumerable<UserFilterRsp>>(users);

            return new ResponseViewModel() { RtnData = userRsp };
        }

        public async Task<ResponseViewModel> GetBusinessmensFilter(UserParams userParams)
        {
            userParams.Role = ((int)RoleEnum.Manager).ToString();
            var users = await _repostioryWrapper.userRepository.GetUsersFilter(userParams);

            var userRsp = _mapper.Map<IEnumerable<UserFilterRsp>>(users);

            return new ResponseViewModel() { RtnData = userRsp };
        }

        public async Task<ResponseViewModel> GetUserAndInsiderByUserId(string userId)
        {
            var users = await _repostioryWrapper.userRepository.GetUserAndInsiderByUserId(userId);

            if(users.Count()==0)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = "查無業務資料" };

            if (users.Count() > 1)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.GetFail, RtnMessage = "資料有誤" };

            var businessmanRsp = _mapper.Map<BusinessmanRsp>(users.ToList().SingleOrDefault());
            return new ResponseViewModel() { RtnCode = ReturnCodeEnum.Ok, RtnData=businessmanRsp };

        }

        public async Task<ResponseViewModel> PostBusinessmanAndInsider(PostUserAndInsiderViewModel postUserAndInsiderViewModal)
        {
            var user = await _repostioryWrapper.userRepository.GetByUserId(postUserAndInsiderViewModal.UserId);
            if (user != null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.AuthenticationLogicFail, RtnMessage = "驗證失敗", RtnData = "已有重複帳號" };

            var postUserAndInsiderReq = _mapper.Map<PostUserAndInsiderReq>(postUserAndInsiderViewModal);
            postUserAndInsiderReq.Status = AccountStatusEnum.Activate;

            var result = await _repostioryWrapper.userRepository.PostUserAndInsider(postUserAndInsiderReq);
            if (result)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.Ok, RtnMessage = "新增成功" };
            else
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "新增失敗" };
        }

        public async Task<ResponseViewModel> UpdateBusinessmanAndInsider(UpdateUserAndInsiderViewModel updateUserAndInsiderViewModal)
        {
            var updateUserAndInsiderReq = _mapper.Map<UpdateUserAndInsiderReq>(updateUserAndInsiderViewModal);
            updateUserAndInsiderReq.LastModifier = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name).Value;
            var result = await _repostioryWrapper.userRepository.UpdateUserAndInsider(updateUserAndInsiderReq);
            if (result)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.Ok, RtnMessage = "修改成功" };
            else
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "修改失敗" };
        }
    }
}
