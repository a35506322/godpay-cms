using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Common.Helpers;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;

namespace GodPay_CMS.Common.Profiles
{
    public class PersonnelProfile : Profile
    {
        public PersonnelProfile()
        {
            CreateMap<PersonnelByStore, PersonnelRsp>()
                .ForMember(n => n.Role, o => o.MapFrom(o => ((RoleEnum)o.Role).GetEnumDescription()))
                .ForMember(n => n.Status, o => o.MapFrom(o => ((AccountStatusEnum)o.Status).GetEnumDescription()));
        }
    }
}
