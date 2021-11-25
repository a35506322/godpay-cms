using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Common.Helpers;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;

namespace GodPay_CMS.Common.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserRsp>();

            CreateMap<User, UserFilterRsp>()
                    .ForMember(n => n.Role, o => o.MapFrom(o => ((RoleEnum)o.Role).GetEnumDescription()))
                    .ForMember(n => n.Status, o => o.MapFrom(o => ((AccountStatusEnum)o.Status).GetEnumDescription()));

            CreateMap<EditUserViewModel, UpdateUserReq>();

            CreateMap<PostUserAndInsiderViewModal, PostUserAndInsiderReq>();                   
        }
    }
}
