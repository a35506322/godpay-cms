using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Common.Helpers;
using GodPay_CMS.Common.Util;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;
using System;

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

            CreateMap<PostUserAndInsiderViewModel, PostUserAndInsiderReq>()
                       .ForMember(n => n.UserKey, o => o.MapFrom(o => RNGCrypto.HMACSHA256("p@ssw0rd", o.UserId)))
                       .ForMember(n => n.Role, o => o.MapFrom(t => RoleEnum.Manager))
                       .ForMember(n => n.CreateDate, o => o.MapFrom(t => DateTime.Now))
                       .ForMember(n => n.Func, o => o.MapFrom(t => 0));

            CreateMap<User, BusinessmanRsp>()
                    .ForMember(n => n.Name, o => o.MapFrom(o => o.Insider.Name))
                    .ForMember(n => n.Department, o => o.MapFrom(o => o.Insider.Department));

            CreateMap<UpdateUserAndInsiderViewModel, UpdateUserAndInsiderReq>()
                    .ForMember(n => n.LastModifyDate, o => o.MapFrom(t => DateTime.Now));

            CreateMap<PostUserAndStoreViewModel, PostUserAndStoreReq>()
                       .ForMember(n => n.UserKey, o => o.MapFrom(o => RNGCrypto.HMACSHA256("p@ssw0rd", o.UserId)))
                       .ForMember(n => n.Role, o => o.MapFrom(t => RoleEnum.Store))
                       .ForMember(n => n.CreateDate, o => o.MapFrom(t => DateTime.Now))
                       .ForMember(n => n.Func, o => o.MapFrom(t => 0));
            CreateMap<User, StoreRsp>()
                       .ForMember(n => n.FullName, o => o.MapFrom(o => o.Store.FullName))
                       .ForMember(n => n.ShortName, o => o.MapFrom(o => o.Store.ShortName))
                       .ForMember(n => n.StoreData1, o => o.MapFrom(o => o.Store.StoreData1))
                       .ForMember(n => n.StoreData2, o => o.MapFrom(o => o.Store.StoreData2));
        }
    }
}
