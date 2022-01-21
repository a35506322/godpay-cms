using AutoMapper;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;

namespace GodPay_CMS.Common.Profiles
{
    public class Customer_StoreProfile:Profile
    {   
        public Customer_StoreProfile()
        {
            CreateMap<Customer_Store, StoreFilterRsp>()
                .ForMember(n =>n.CustomerName,o=>o.MapFrom(o=>o.Customer.CustomerName));

            CreateMap<UpdateStoreViewModel, Customer_Store>()
                .ForMember(n => n.User, o => o.MapFrom(t => new User()));

            CreateMap<Customer_Store, StoreDDLRsp>();
        }
    }
}
