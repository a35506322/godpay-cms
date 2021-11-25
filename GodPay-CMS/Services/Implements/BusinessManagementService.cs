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
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = "查無使用者資料" };

            var insiderRsp = _mapper.Map<InsiderFilterRsp>(insider);

            return new ResponseViewModel() { RtnData = insiderRsp };
        }

        public async Task<ResponseViewModel> GetBusinessmens()
        {
            var users = await _repostioryWrapper.userRepository.GetByRole(RoleEnum.Manager);

            if (users == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = "查無錯誤",RtnData= "查無使用者資料" };

            var userRsp = _mapper.Map<IEnumerable<UserFilterRsp>>(users);

            return new ResponseViewModel() { RtnData = userRsp };
        }

        public async Task<ResponseViewModel> PostBusinessmanBAndInsider(PostUserAndInsiderViewModal postUserAndInsiderViewModal)
        {
            var postUserAndInsiderReq = _mapper.Map<PostUserAndInsiderReq>(postUserAndInsiderViewModal);
            postUserAndInsiderReq.UserKey = RNGCrypto.HMACSHA256("p@ssw0rd", postUserAndInsiderReq.UserId);
            postUserAndInsiderReq.Role = RoleEnum.Manager;
            postUserAndInsiderReq.CreateDate = DateTime.Now;
            postUserAndInsiderReq.Func = 0;

            var result = await _repostioryWrapper.userRepository.PostBusinessmanBAndInsider(postUserAndInsiderReq);
            if (result)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.Ok, RtnMessage = "新增成功" };
            else
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "新增失敗" };
        }
    }
}
