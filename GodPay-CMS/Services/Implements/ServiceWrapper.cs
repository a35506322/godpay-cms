using GodPay_CMS.Services.Interfaces;

namespace GodPay_CMS.Services.Implements
{
    public class ServiceWrapper : IServiceWrapper
    {
        private readonly ISigninService _signinService;
        private readonly IAuthorityService _authorityService;
        private readonly IUserService _userService;

        public ServiceWrapper(ISigninService signinService, IAuthorityService authorityService, IUserService userService)
        {
            _signinService = signinService;
            _authorityService = authorityService;
            _userService = userService;
        }

        public ISigninService signinService => _signinService;
        public IAuthorityService authorityService => _authorityService;
        public IUserService userService => _userService;
    }
}
