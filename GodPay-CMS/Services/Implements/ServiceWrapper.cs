using GodPay_CMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Implements
{
    public class ServiceWrapper : IServiceWrapper
    {
        public readonly ISigninService _signinService;
        public ServiceWrapper(ISigninService signinService)
        {
            _signinService = signinService;
        }
        public ISigninService signinService => _signinService;
    }
}
