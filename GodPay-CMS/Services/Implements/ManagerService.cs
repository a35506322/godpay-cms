using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Common.Helpers;
using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.DTO;
using GodPay_CMS.Services.DTO.Request;
using GodPay_CMS.Services.DTO.Response;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Implements
{
    public class ManagerService : IManagerService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepostioryWrapper _repostioryWrapper;
        private readonly IMapper _mapper;
        public ManagerService(IRepostioryWrapper repostioryWrapper, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _repostioryWrapper = repostioryWrapper;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseViewModel> GetManagerAll()
        {
            UserParams userParams = new UserParams() { Role = (int)RoleEnum.Manager };
            var users = await _repostioryWrapper.userRepository.GetUsersFilter(userParams);

            var userRsp = _mapper.Map<IEnumerable<UserFilterRsp>>(users);

            return new ResponseViewModel() { RtnData = userRsp };
        }

        public async Task<ResponseViewModel> GetManagerDeatil(int uid)
        {
            var insider = await _repostioryWrapper.insiderRepository.GetById(uid);

            if (insider == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = ReturnCodeEnum.NotFound.GetEnumDescription() };

            var insiderRsp = _mapper.Map<InsiderFilterRsp>(insider);

            return new ResponseViewModel() { RtnData = insiderRsp };
        }

        public async Task<ResponseViewModel> PostManagerAndInsider(PostUserAndInsiderReq postUserAndInsiderReq)
        {
            var user = await _repostioryWrapper.userRepository.GetByUserId(postUserAndInsiderReq.UserId);
            if (user != null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.AuthenticationLogicFail, RtnData = "已有重複帳號", RtnMessage = ReturnCodeEnum.AuthenticationLogicFail.GetEnumDescription() };

            var result = await _repostioryWrapper.userRepository.PostUserAndInsider(postUserAndInsiderReq);
            if (result)
                return new ResponseViewModel();
            else
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = ReturnCodeEnum.ExecutionFail.GetEnumDescription() };
        }

        public async Task<ResponseViewModel> UpdateManagerAndInsider(PutUserAndInsiderReq putUserAndInsiderReq)
        {
            putUserAndInsiderReq.LastModifier = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name).Value;
            putUserAndInsiderReq.LastModifyDate = DateTime.Now;

            var result = await _repostioryWrapper.userRepository.UpdateUserAndInsider(putUserAndInsiderReq);
            if (result)
                return new ResponseViewModel();
            else
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = ReturnCodeEnum.ExecutionFail.GetEnumDescription() };
        }

        public async Task<ResponseViewModel> GetManagerAndInsiderByUserId(string userId)
        {
            var users = await _repostioryWrapper.userRepository.GetUserAndInsiderByUserId(userId);

            if (users == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = ReturnCodeEnum.NotFound.GetEnumDescription() };

            var businessmanRsp = _mapper.Map<ManagerRsp>(users);
            return new ResponseViewModel() { RtnCode = ReturnCodeEnum.Ok, RtnData = businessmanRsp };

        }

        public async Task<ResponseViewModel> GetManagerFilter(UserParams userParams)
        {
            userParams.Role = ((int)RoleEnum.Manager);
            var users = await _repostioryWrapper.userRepository.GetUsersFilter(userParams);

            var userRsp = _mapper.Map<IEnumerable<UserFilterRsp>>(users);

            return new ResponseViewModel() { RtnData = userRsp };
        }

        public async Task<ResponseViewModel> GetManagerAuthority(string userId)
        {
            var user = await _repostioryWrapper.userRepository.GetByUserId(userId);
            if (user == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = ReturnCodeEnum.NotFound.GetEnumDescription() };

            GetRoleAuthorityReq getRoleAuthorityReq = new GetRoleAuthorityReq()
            {
                Role = (int)RoleEnum.Manager,
                FuncFlag = user.Func
            };

            var managerAuthority = await _repostioryWrapper.funcClassRepository.GetRoleAuthority(getRoleAuthorityReq);
            return new ResponseViewModel() { RtnData = managerAuthority };
        }

        public async Task<ResponseViewModel> UpdateManagerAuthority(PutUserAuthorityReq putUserAuthorityReq)
        {
            var updateUserAuthorityReq = _mapper.Map<User>(putUserAuthorityReq);
            updateUserAuthorityReq.LastModifier = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name).Value;
            updateUserAuthorityReq.LastModifyDate = DateTime.Now;

            var result = await _repostioryWrapper.userRepository.UpdateUserAuthority(updateUserAuthorityReq);
            if (result)
                return new ResponseViewModel();
            else
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = ReturnCodeEnum.ExecutionFail.GetEnumDescription() };
        }
    }
}
