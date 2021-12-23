using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.Parameters;
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
    public class StoreService : IStoreService
    {
        private readonly IRepostioryWrapper _repostioryWrapper;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public StoreService(IRepostioryWrapper repostioryWrapper, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _repostioryWrapper = repostioryWrapper;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseViewModel> GetStoreDeatil(int uid)
        {
            var store = await _repostioryWrapper.storeRepository.GetById(uid);

            var storeRsp = _mapper.Map<StoreFilterRsp>(store);

            if (store == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = "查無特店詳細資料" };

            return new ResponseViewModel() { RtnData = storeRsp };
        }

        public async Task<ResponseViewModel> GetStores()
        {
            var stores = await _repostioryWrapper.userRepository.GetByRole(RoleEnum.Store);

            var storesRsp = _mapper.Map<IEnumerable<UserFilterRsp>>(stores);

            return new ResponseViewModel() { RtnData = storesRsp };
        }

        public async Task<ResponseViewModel> PostUserAndStore(PostUserAndStoreViewModel postUserAndStoreViewModel)
        {
            var user = await _repostioryWrapper.userRepository.GetByUserId(postUserAndStoreViewModel.UserId);
            if (user != null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.AuthenticationLogicFail, RtnMessage = "驗證失敗", RtnData = "已有重複帳號" };

            var storeReq = _mapper.Map<PostUserAndStoreReq>(postUserAndStoreViewModel);

            var result = await _repostioryWrapper.userRepository.PostUserAndStore(storeReq);

            if (result)
                return new ResponseViewModel() { RtnMessage = "新增成功" };
            else
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "新增失敗" };
        }

        public async Task<ResponseViewModel> GetUserAndStoreByUserId(string userId)
        {
            var users = await _repostioryWrapper.userRepository.GetUserAndStoreByUserId(userId);
            if (users.Count() == 0)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = "查無資料" };

            if (users.Count() > 1)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.GetFail, RtnMessage = "資料有誤" };

            var storeRsp = _mapper.Map<StoreParticularsRsp>(users.ToList().SingleOrDefault());
            return new ResponseViewModel() { RtnCode = ReturnCodeEnum.Ok, RtnData = storeRsp };
        }

        public async Task<ResponseViewModel> GetStoreFilter(UserParams userParams)
        {
            var users = await _repostioryWrapper.userRepository.GetUsersFilter(userParams);
            var storeRsp = _mapper.Map<IEnumerable<UserFilterRsp>>(users);
            return new ResponseViewModel() { RtnData = storeRsp };
        }

        public async Task<ResponseViewModel> UpateUserAndStore(UpdateUserAndStoreViewModel updateUserAndStoreViewModel)
        {
            var updateUserAndStoreReq = _mapper.Map<UpdateUserAndStoreReq>(updateUserAndStoreViewModel);
            updateUserAndStoreReq.LastModifier = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name).Value;
            updateUserAndStoreReq.LastModifyDate = DateTime.Now;

            var result = await _repostioryWrapper.userRepository.UpateUserAndStore(updateUserAndStoreReq);
            if (result)
                return new ResponseViewModel() { RtnMessage = "修改成功" };

            return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "修改失敗" };
        }

        public async Task<ResponseViewModel> UpateStore(UpdateStoreViewModel updateStoreViewModel)
        {
            var storeDeatail = await _repostioryWrapper.storeRepository.GetById(updateStoreViewModel.Uid);
            if (storeDeatail == null) { return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = "查無此詳細資料" }; }

            var updateStoreReq = _mapper.Map<Store>(updateStoreViewModel);
            var result = await _repostioryWrapper.storeRepository.Update(updateStoreReq);

            if (result) { return new ResponseViewModel() { RtnMessage = "修改成功" }; }

            return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "修改失敗" };
        }
    }
}
