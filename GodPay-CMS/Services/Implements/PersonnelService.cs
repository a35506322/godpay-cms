using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Common.Util;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;
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
    public class PersonnelService : IPersonnelService
    {
        private readonly IMapper _mapper;
        private readonly IRepostioryWrapper _repostioryWrapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PersonnelService(IRepostioryWrapper repostioryWrapper, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _repostioryWrapper = repostioryWrapper;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseViewModel> GetAllPersonnelByStore()
        {
            if (!_httpContextAccessor.HttpContext.User.HasClaim(c => c.Type == "StoreId"))
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.GetFail, RtnMessage = "取得特店人員失敗" };

            var user = await _repostioryWrapper.personnelRepository.GetAllPersonnelByStore();

            if (user == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = "查無使用者資料" };

            var userRsp = _mapper.Map<IEnumerable<PersonnelRsp>>(user);
            return new ResponseViewModel() { RtnData = userRsp };
        }

        public async Task<ResponseViewModel> GetStorePersonnelAuthority(string userId)
        {
            var user = await _repostioryWrapper.userRepository.GetByUserId(userId);
            if (user == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = "查無使用者資料" };

            GetRoleAuthorityReq getRoleAuthorityReq = new GetRoleAuthorityReq()
            {
                Role = (int)RoleEnum.Personnel,
                FuncFlag = user.Func
            };
            var managerAuthority = await _repostioryWrapper.funcClassRepository.GetRoleAuthority(getRoleAuthorityReq);
            return new ResponseViewModel() { RtnData = managerAuthority };
        }

        public async Task<ResponseViewModel> PostStorePersonnel(PostStorePersonnelViewModel postStorePersonnelViewModel)
        {
            string loginId = $"{_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name).Value}_";
            string postId = $"{loginId}{postStorePersonnelViewModel.UserId.Trim()}";

            var user = await _repostioryWrapper.userRepository.GetByUserId(postId);
            if (user != null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.AuthenticationLogicFail, RtnMessage = "此帳號已重複" };

            var postUserReq = _mapper.Map<User>(postStorePersonnelViewModel);
            postUserReq.UserId = postId;
            postUserReq.UserKey = RNGCrypto.HMACSHA256("p@ssw0rd",postId);
            postUserReq.Personnel = new Personnel();
            postUserReq.Personnel.StoreId = Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == "StoreId").Value);

            var isSuccess = await _repostioryWrapper.userRepository.PostStorePersonnel(postUserReq);
            if(isSuccess)
                return new ResponseViewModel() { RtnMessage = "新增特店人員成功" };
            else
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "新增特店人員失敗" };
        }

        public async Task<ResponseViewModel> UpdateStorePersonnel(UpdateStorePersonnelViewModel updateStorePersonnelViewModel)
        {
            var user = await _repostioryWrapper.userRepository.GetByUserId(updateStorePersonnelViewModel.UserId);
            if (user == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.AuthenticationLogicFail, RtnMessage = "此帳號不存在" };

            var updateUserReq = _mapper.Map<User>(updateStorePersonnelViewModel);

            var isSuccess = await _repostioryWrapper.userRepository.UpdateStorePersonnel(updateUserReq);
            if (isSuccess)
                return new ResponseViewModel() { RtnMessage = "修改特店人員成功" };
            else
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "修改特店人員失敗" };

        }

        public async Task<ResponseViewModel> UpdateStorePersonnelAuthority(UpdateUserAuthorityViewModel updateUserAuthorityViewModel)
        {
            var updateUserAuthorityReq = _mapper.Map<User>(updateUserAuthorityViewModel);
            updateUserAuthorityReq.LastModifier = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name).Value;
            updateUserAuthorityReq.LastModifyDate = DateTime.Now;

            var result = await _repostioryWrapper.userRepository.UpdateUserAuthority(updateUserAuthorityReq);
            if (result)
                return new ResponseViewModel() { RtnMessage = "修改特店人員權限成功", RtnData = result };
            else
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "修改特店人員權限失敗" };
        }
    }
}
