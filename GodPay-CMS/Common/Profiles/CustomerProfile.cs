﻿using AutoMapper;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.DTO;

namespace GodPay_CMS.Common.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<AddCustomerViewModel, CustomerReq>();
        }
    }
}