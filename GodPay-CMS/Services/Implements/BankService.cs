using AutoMapper;
using GodPay_CMS.Common.Helpers;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.DTO.Response;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Implements
{
    public class BankService : IBankService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepostioryWrapper _repostioryWrapper;
        private readonly IMapper _mapper;
        public BankService(IRepostioryWrapper repostioryWrapper, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _repostioryWrapper = repostioryWrapper;
            _mapper = mapper;
        }
        public async Task<ResponseViewModel> GetBankDetailById(string code)
        {
            var bankDetail = await _repostioryWrapper.bankDetailRepository.GetById(code);

            if (bankDetail == null)
                return new ResponseViewModel {  RtnCode = Common.Enums.ReturnCodeEnum.NotFound, RtnMessage = Common.Enums.ReturnCodeEnum.NotFound.GetEnumDescription()};

            var bankDetailRsp = _mapper.Map<BankDetailRsp>(bankDetail);

            return new ResponseViewModel { RtnData = bankDetailRsp };
        }
    }
}
