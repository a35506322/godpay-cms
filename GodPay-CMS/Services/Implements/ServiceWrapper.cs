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
        private readonly IUserService _userService;
        private readonly IManagerService _managerService;
        private readonly IStoreService _storeService;
        private readonly IEnumService _enumService;
        public ServiceWrapper(ISigninService signinService,
                              IAuthorityService authorityService,
                              IUserService userService,
                              IManagerService managerService,
                              IStoreService storeService,
                              IEnumService enumService)
        {
            _signinService = signinService;
            _authorityService = authorityService;
            _userService = userService;
            _managerService = managerService;
            _storeService = storeService;
            _enumService = enumService;
        }
        public ISigninService signinService => _signinService;

        public IAuthorityService authorityService => _authorityService;

        public IUserService userService => _userService;

        public IManagerService managerService => _managerService;

        public IStoreService storeService => _storeService;

        public IEnumService enumService => _enumService;
    }
}
