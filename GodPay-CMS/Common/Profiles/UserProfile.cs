using AutoMapper;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Common.Profiles
{
    public class UserProfile :Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserRsp>();
        }
    }
}
