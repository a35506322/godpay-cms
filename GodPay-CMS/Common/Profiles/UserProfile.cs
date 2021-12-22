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

            CreateMap<UpdateUserAndStoreViewModel, UpdateUserAndStoreReq>();

            CreateMap<PostUserAndStoreViewModel, PostUserAndStoreReq>();

            CreateMap<User, StoreParticularsRsp>()
                       .ForMember(n => n.StoreName, o => o.MapFrom(o => o.Store.StoreName))
                       .ForMember(n => n.CustomerId, o => o.MapFrom(o => o.Store.CustomerId))
                       .ForMember(n => n.StoreId, o => o.MapFrom(o => o.Store.StoreId))
                       .ForMember(n => n.TaxId, o => o.MapFrom(o => o.Store.TaxId))
                       .ForMember(n => n.Owner, o => o.MapFrom(o => o.Store.Owner))
                       .ForMember(n => n.Address, o => o.MapFrom(o => o.Store.Address))
                       .ForMember(n => n.OwnerEmail, o => o.MapFrom(o => o.Store.OwnerEmail));

            CreateMap<UpdateUserAuthorityViewModel, UpdateUserAuthorityReq>();
        }
    }
}
