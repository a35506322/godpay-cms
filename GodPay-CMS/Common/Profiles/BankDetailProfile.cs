using AutoMapper;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Common.Profiles
{
    public class BankDetailProfile: Profile
    {
        public BankDetailProfile()
        {
            CreateMap<BankDetail, BankDetailRsp>();
        }
    }
}
