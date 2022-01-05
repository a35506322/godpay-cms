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

        public async Task<ResponseViewModel> PostStorePersonnel(PostStorePersonnelViewModel postStorePersonnelViewModel)
        {
            string loginId = $"{_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name).Value}_";
            string postId = $"{loginId}{postStorePersonnelViewModel.UserId.Trim()}";

            var user = await _repostioryWrapper.userRepository.GetByUserId(postId);
            if (user != null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.AuthenticationLogicFail, RtnMessage = "此帳號已重複" };

            var postUserReq = _mapper.Map<User>(postStorePersonnelViewModel);
            postUserReq.UserId = postId;
            postUserReq.UserKey = RNGCrypto.HMACSHA256(postId, "p@ssw0rd");
            postUserReq.Personnel = new Personnel();
            postUserReq.Personnel.StoreId = Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == "StoreId").Value);

            var isSuccess = await _repostioryWrapper.userRepository.PostStorePersonnel(postUserReq);
            if(isSuccess)
                return new ResponseViewModel() { RtnMessage = "新增特店人員成功" };
            else
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "新增特店人員失敗" };
        }
    }
}
