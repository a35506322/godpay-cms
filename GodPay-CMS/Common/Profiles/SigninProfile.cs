using AutoMapper;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;

namespace GodPay_CMS.Common.Profiles
{
    public class SigninProfile : Profile
    {
        public SigninProfile()
        {
            CreateMap<SigninViewModel, SigninReq>();
            CreateMap<User, UserRsp>();
        }
    }
}
