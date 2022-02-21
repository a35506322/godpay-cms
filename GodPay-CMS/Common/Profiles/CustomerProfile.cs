using AutoMapper;
using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO.Request;

namespace GodPay_CMS.Common.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {            
            CreateMap<PostCustomerReq, CustomerParams>();
            CreateMap<PostCustomerReq, Customer>();
            CreateMap<PutCustomerReq, CustomerParams>();
            CreateMap<PutCustomerReq, Customer>();          
        }
    }
}
