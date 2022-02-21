using AutoMapper;
using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;
using GodPay_CMS.Services.DTO.Request;
using GodPay_CMS.Services.DTO.Response;

namespace GodPay_CMS.Common.Profiles
{
    public class FuncClassProfile : Profile
    {
        public  FuncClassProfile ()
        {
            CreateMap<FuncClass, FuncClassRsp>()
                // 名字不同記得轉換
                .ForMember(n => n.FuncRsps, o => o.MapFrom(o => o.Funcs));
            CreateMap<FuncClass, AuthorityFuncClassRsp>()
                // 名字不同記得轉換
                .ForMember(n => n.Functions, o => o.MapFrom(o => o.Funcs));
            CreateMap<FunctionParams, GetByFuncClassAndFuncFilterReq>();
            CreateMap<PostFuncClassReq, FuncClass>();
            CreateMap<PutFuncClassReq, FuncClass>();
        }
    }
}
