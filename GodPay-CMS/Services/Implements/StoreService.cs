using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Common.Helpers;
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
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = ReturnCodeEnum.NotFound.GetEnumDescription() };

            return new ResponseViewModel() { RtnData = storeRsp };
        }

        public async Task<ResponseViewModel> GetStores()
        {
            UserParams userParams = new UserParams(){ Role = (int)RoleEnum.Store};

            var stores = await _repostioryWrapper.userRepository.GetUsersFilter(userParams);
            var storesRsp = _mapper.Map<IEnumerable<UserFilterRsp>>(stores);

            return new ResponseViewModel() { RtnData = storesRsp };
        }

        public async Task<ResponseViewModel> PostUserAndStore(PostUserAndStoreViewModel postUserAndStoreViewModel)
        {
            var user = await _repostioryWrapper.userRepository.GetByUserId(postUserAndStoreViewModel.UserId);
            if (user != null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.AuthenticationLogicFail, RtnMessage = ReturnCodeEnum.AuthenticationLogicFail.GetEnumDescription(), RtnData = "已有重複帳號" };

            var storeReq = _mapper.Map<PostUserAndStoreReq>(postUserAndStoreViewModel);

            var result = await _repostioryWrapper.userRepository.PostUserAndStore(storeReq);

            if (result)
                return new ResponseViewModel();
            else
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = ReturnCodeEnum.ExecutionFail.GetEnumDescription() };
        }

        public async Task<ResponseViewModel> GetUserAndStoreByUserId(string userId)
        {
            var users = await _repostioryWrapper.userRepository.GetUserAndStoreByUserId(userId);
            if (users.Count() == 0)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = ReturnCodeEnum.NotFound.GetEnumDescription() };

            if (users.Count() > 1)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.GetFail, RtnMessage = ReturnCodeEnum.GetFail.GetEnumDescription(), RtnData="此特店帳號存在兩筆" };

            var storeRsp = _mapper.Map<StoreParticularsRsp>(users.ToList().SingleOrDefault());
            return new ResponseViewModel() { RtnCode = ReturnCodeEnum.Ok, RtnData = storeRsp };
        }

        public async Task<ResponseViewModel> UpateUserAndStore(UpdateUserAndStoreViewModel updateUserAndStoreViewModel)
        {
            var updateUserAndStoreReq = _mapper.Map<UpdateUserAndStoreReq>(updateUserAndStoreViewModel);
            updateUserAndStoreReq.LastModifier = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name).Value;
            updateUserAndStoreReq.LastModifyDate = DateTime.Now;

            var result = await _repostioryWrapper.userRepository.UpateUserAndStore(updateUserAndStoreReq);
            if (result)
                return new ResponseViewModel();

            return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = ReturnCodeEnum.ExecutionFail.GetEnumDescription() };
        }

        public async Task<ResponseViewModel> UpateStore(UpdateStoreViewModel updateStoreViewModel)
        {
            var storeDeatail = await _repostioryWrapper.storeRepository.GetById(updateStoreViewModel.Uid);
            if (storeDeatail == null) { return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = ReturnCodeEnum.NotFound.GetEnumDescription() }; }

            var updateStoreReq = _mapper.Map<Customer_Store>(updateStoreViewModel);
            updateStoreReq.User.LastModifier = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name).Value;
            updateStoreReq.User.LastModifyDate = DateTime.Now;
            var result = await _repostioryWrapper.storeRepository.Update(updateStoreReq);

            if (result) { return new ResponseViewModel(); }

            return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = ReturnCodeEnum.ExecutionFail.GetEnumDescription() };
        }

        public async Task<ResponseViewModel> GetStoreAuthority(string userId)
        {
            var user = await _repostioryWrapper.userRepository.GetByUserId(userId);
            if (user == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = ReturnCodeEnum.NotFound.GetEnumDescription() };

            GetRoleAuthorityReq getRoleAuthorityReq = new GetRoleAuthorityReq()
            {
                Role = (int)RoleEnum.Store,
                FuncFlag = user.Func
            };
            var storeAuthority = await _repostioryWrapper.funcClassRepository.GetRoleAuthority(getRoleAuthorityReq);
            return new ResponseViewModel() { RtnData = storeAuthority };
        }

        public async Task<ResponseViewModel> UpdateStoreAuthority(UpdateUserAuthorityViewModel updateUserAuthorityViewModel)
        {
            var updateUserAuthorityReq = _mapper.Map<User>(updateUserAuthorityViewModel);
            updateUserAuthorityReq.LastModifier = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name).Value;
            updateUserAuthorityReq.LastModifyDate = DateTime.Now;

            var result = await _repostioryWrapper.userRepository.UpdateUserAuthority(updateUserAuthorityReq);
            if (result)
                return new ResponseViewModel() {  RtnData = result };
            else
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = ReturnCodeEnum.ExecutionFail.GetEnumDescription() };
        }

        public async Task<ResponseViewModel> GetStoreForDDL(string customerId)
        {
            Customer_Store customer_Store = new Customer_Store();
            customer_Store.CustomerId = Guid.Parse(customerId);

            var stores = await _repostioryWrapper.storeRepository.GetStoresCondition(customer_Store);
            var result = _mapper.Map<IEnumerable<StoreDDLRsp>>(stores);
            return new ResponseViewModel() {RtnData = result };
        }
    }
}
