using AutoMapper;
using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;

namespace GodPay_CMS.Common.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<EditCustomerViewModel, CustomerParams>();
            CreateMap<AddCustomerViewModel, Customer>();
            CreateMap<EditCustomerViewModel, Customer>();
            CreateMap<AddCustomerViewModel, CustomerParams>();
        }
    }
}
