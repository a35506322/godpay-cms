using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Common.Helpers;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;
using GodPay_CMS.Services.DTO.Request;
using GodPay_CMS.Services.DTO.Response;
using System;

namespace GodPay_CMS.Common.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<PostSigninReq, User>();

            CreateMap<PutUserReq, User>();

            CreateMap<User, UserFilterRsp>()
                    .ForMember(n => n.LastChangePwdDate, o => o.MapFrom(o => o.LastChangePwdDate != null ? o.LastChangePwdDate.Value.ToString("yyyy/MM/dd HH:mm:ss"):null))
                    .ForMember(n => n.LastModifyDate, o => o.MapFrom(o => o.LastModifyDate != null ? o.LastModifyDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null))
                    .ForMember(n => n.LastLoginDate, o => o.MapFrom(o => o.LastLoginDate != null ? o.LastLoginDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null))
                    .ForMember(n => n.RoleChName,o => o.MapFrom(o => ((RoleEnum)o.Role).GetEnumDescription()))
                    .ForMember(n => n.StatusChName, o => o.MapFrom(o => ((AccountStatusEnum)o.Status).GetEnumDescription()));

            CreateMap<User, ManagerRsp>()
                    .ForMember(n => n.Name, o => o.MapFrom(o => o.Insider.Name))
                    .ForMember(n => n.Department, o => o.MapFrom(o => o.Insider.Department));

            CreateMap<User, StoreParticularsRsp>()
                       .ForMember(n => n.StoreName, o => o.MapFrom(o => o.Customer_Store.StoreName))
                       .ForMember(n => n.CustomerId, o => o.MapFrom(o => o.Customer_Store.CustomerId))
                       .ForMember(n => n.StoreId, o => o.MapFrom(o => o.Customer_Store.StoreId))
                       .ForMember(n => n.TaxId, o => o.MapFrom(o => o.Customer_Store.TaxId))
                       .ForMember(n => n.Owner, o => o.MapFrom(o => o.Customer_Store.Owner))
                       .ForMember(n => n.Address, o => o.MapFrom(o => o.Customer_Store.Address))
                       .ForMember(n => n.OwnerEmail, o => o.MapFrom(o => o.Customer_Store.OwnerEmail))
                       .ForMember(n => n.ReceivingBankCode, o => o.MapFrom(o => o.Customer_Store.ReceivingBankCode))
                       .ForMember(n => n.ReceivingAccount, o => o.MapFrom(o => o.Customer_Store.ReceivingAccount))
                       .ForMember(n => n.ReceivingBranch, o => o.MapFrom(o => o.Customer_Store.ReceivingBranch))
                       .ForMember(n => n.MoneyTransferDay, o => o.MapFrom(o => o.Customer_Store.MoneyTransferDay));

            CreateMap<PutUserAuthorityReq, User>();

            CreateMap<PostStorePersonnelReq, User>()
                        .ForMember(n => n.Role, o => o.MapFrom(t => RoleEnum.Personnel))
                        .ForMember(n => n.Status, o => o.MapFrom(t => AccountStatusEnum.ToBeOpened))
                        .ForMember(n => n.Func, o => o.MapFrom(t => 3))
                        .ForMember(n=>n.CreateDate,o => o.MapFrom(t => DateTime.Now));

            CreateMap<PutStorePersonnelReq, User>();
        }
    }
}
