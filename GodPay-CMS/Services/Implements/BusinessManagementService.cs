using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Common.Util;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.DTO;
using GodPay_CMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Implements
{
    public class BusinessManagementService : IBusinessManagementService
    {
        private readonly IRepostioryWrapper _repostioryWrapper;
        private readonly IMapper _mapper;
        public BusinessManagementService(IRepostioryWrapper repostioryWrapper, IMapper mapper)
        {
            _repostioryWrapper = repostioryWrapper;
            _mapper = mapper;
        }

        public async Task<ResponseViewModel> GetBusinessmenDeatil(string id)
        {
            var insider = await _repostioryWrapper.insiderRepository.GetById(id);

            if (insider == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = "查無業務詳細資料" };

            var insiderRsp = _mapper.Map<InsiderFilterRsp>(insider);

            return new ResponseViewModel() { RtnData = insiderRsp };
        }

        public async Task<ResponseViewModel> GetBusinessmens()
        {
            var users = await _repostioryWrapper.userRepository.GetByRole(RoleEnum.Manager);

            if (users == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = "查無業務資料" };

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

        public async Task<ResponseViewModel> PostBusinessmanAndInsider(PostUserAndInsiderViewModal postUserAndInsiderViewModal)
        {
            var postUserAndInsiderReq = _mapper.Map<PostUserAndInsiderReq>(postUserAndInsiderViewModal);
            postUserAndInsiderReq.UserKey = RNGCrypto.HMACSHA256("p@ssw0rd", postUserAndInsiderReq.UserId);
            postUserAndInsiderReq.Role = RoleEnum.Manager;
            postUserAndInsiderReq.CreateDate = DateTime.Now;
            postUserAndInsiderReq.Func = 0;

            var user = await _repostioryWrapper.userRepository.GetByUserId(postUserAndInsiderViewModal.UserId);
            if (user != null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.AuthenticationLogicFail, RtnMessage = "驗證失敗",RtnData="已有重複帳號" };

            var result = await _repostioryWrapper.userRepository.PostBusinessmanAndInsider(postUserAndInsiderReq);
            if (result)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.Ok, RtnMessage = "新增成功" };
            else
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "新增失敗" };
        }
    }
}
