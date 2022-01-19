using GodPay_CMS.Services.Interfaces;

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
        private readonly ICustomerService _customerService;
        private readonly ITagService _itagService;
        private readonly IPersonnelService _personnelService;
        private readonly IGLBDOperationAndTransactionRecordService _glbd_OperationAndTransactionRecordService;

        public ServiceWrapper(ISigninService signinService,
                              IAuthorityService authorityService,
                              IUserService userService,
                              IManagerService managerService,
                              IStoreService storeService,
                              IEnumService enumService,
                              ICustomerService customerService,
                              ITagService tagService,
                              IPersonnelService personnelService,
                              IGLBDOperationAndTransactionRecordService glbd_OperationAndTransactionRecordService)
        {
            _signinService = signinService;
            _authorityService = authorityService;
            _userService = userService;
            _managerService = managerService;
            _storeService = storeService;
            _enumService = enumService;
            _customerService = customerService;
            _itagService = tagService;
            _personnelService = personnelService;
            _glbd_OperationAndTransactionRecordService = glbd_OperationAndTransactionRecordService;
        }
        public ISigninService signinService => _signinService;

        public IAuthorityService authorityService => _authorityService;

        public IUserService userService => _userService;

        public IManagerService managerService => _managerService;

        public IStoreService storeService => _storeService;

        public IEnumService enumService => _enumService;

        public ICustomerService customerService => _customerService;

        public ITagService itagService => _itagService;

        public IPersonnelService personnelService => _personnelService;

        public IGLBDOperationAndTransactionRecordService glbd_OperationAndTransactionRecordService => _glbd_OperationAndTransactionRecordService;
    }
}
