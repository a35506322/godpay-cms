using AutoMapper;
using GodPay_CMS.Common.Enums;
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
            CreateMap<Func, AuthorityFuncRsp>()
                .ForMember(n => n.RoleFlag, o => o.MapFrom(o => Enum.GetValues(typeof(RoleEnum))
                                                            .Cast<int>()
                                                            .Where(r => Convert.ToBoolean(r & o.RoleFlag))
                                                            .ToArray()));
            CreateMap<UpdateFuncViewModel, UpdateRoleAuthorityReq>()
                .ForMember(n => n.RoleFlag, o => o.MapFrom(o => o.RoleFlag.Sum()));
            CreateMap<Func, UpdateRoleAuthorityReq>();
        }
    }
}
