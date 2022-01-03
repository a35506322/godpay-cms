using AutoMapper;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;

namespace GodPay_CMS.Common.Profiles
{
    public class InsiderProfile :Profile
    {
        public InsiderProfile()
        {
            CreateMap<Insider, InsiderFilterRsp>();
        }
    }
}
