using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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

            return new ResponseViewModel() { RtnData = user };
        }
    }
}
