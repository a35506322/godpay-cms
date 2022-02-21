using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;
using GodPay_CMS.Services.DTO.Response;
using GodPay_CMS.Services.DTO.Request;
using System;
using System.Linq;

namespace GodPay_CMS.Common.Profiles
{
    public class FuncProfile : Profile
    {
        public FuncProfile()
        {
            CreateMap<Func, FuncRsp>()
                // 名字不同記得轉換
                .ForMember(n => n.FuncClassRsp, o => o.MapFrom(o => o.FuncClass));
            CreateMap<Func, AuthorityFuncRsp>()
                .ForMember(n => n.RoleFlag, o => o.MapFrom(o => Enum.GetValues(typeof(RoleEnum))
                                                            .Cast<int>()
                                                            .Where(r => Convert.ToBoolean(r & o.RoleFlag))
                                                            .ToArray()));

            CreateMap<PutAuthorityFuncReq, Func>()
                .ForMember(n => n.RoleFlag, o => o.MapFrom(o => o.RoleFlag.Sum()));    
            CreateMap<PostFuncReq, Func>()
                .ForMember(n => n.RoleFlag, o => o.MapFrom(o => 0));
            CreateMap<PutFuncReq, Func>();
            CreateMap<Func, FuncAndFuncClassRsp>()
                .ForMember(n => n.FuncClassChName, o => o.MapFrom(o => o.FuncClass.FuncClassChName));
        }
    }
}
