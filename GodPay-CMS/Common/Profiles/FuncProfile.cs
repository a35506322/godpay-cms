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
    public class FuncProfile : Profile
    {
        public FuncProfile()
        {
            CreateMap<Func, FuncRsp>()
                // 名子不同記得轉換
                .ForMember(n => n.FuncClassRsp, o => o.MapFrom(o => o.FuncClass));
            CreateMap<Func, FuncFilterRsp>();
        }
    }
}
