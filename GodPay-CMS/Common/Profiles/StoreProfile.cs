using AutoMapper;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Common.Profiles
{
    public class StoreProfile:Profile
    {   
        public StoreProfile()
        {
            CreateMap<Store, StoreFilterRsp>()
                .ForMember(n =>n.CustomerName,o=>o.MapFrom(o=>o.Customer.CustomerName));

            CreateMap<UpdateStoreViewModel, Store>()
                .ForMember(n => n.User, o => o.MapFrom(t=> new User())); ;
        }
    }
}
