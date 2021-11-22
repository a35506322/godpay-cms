using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Common.Helpers;
using GodPay_CMS.Common.Util;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;

namespace GodPay_CMS.Common.Profiles
{
    public class SigninProfile : Profile
    {
        public SigninProfile()
        {
            CreateMap<SigninViewModel, SigninReq>()
                .ForMember(n => n.UserKey,
                o => o.MapFrom(src => RNGCrypto.HMACSHA256(src.UserKey, src.UserId)));

            CreateMap<User, UserRsp>();
        }
    }
}
