using GodPay_CMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Implements
{
    public class ServiceWrapper : IServiceWrapper
    {
        private readonly ISigninService _signinService;
        private readonly IAuthorityService _authorityService;
        public ServiceWrapper(ISigninService signinService, IAuthorityService authorityService)
        {
            _signinService = signinService;
            _authorityService = authorityService;
        }
        public ISigninService signinService => _signinService;

        public IAuthorityService authorityService => _authorityService;
    }
}
