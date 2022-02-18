namespace GodPay_CMS.Services.Interfaces
{
    public interface IServiceWrapper
    {
        public ISigninService signinService { get; }
        public IAuthorityService authorityService { get; }
        public IUserService userService { get; }
        public IManagerService managerService { get; }
        public IStoreService storeService { get; }
        public IEnumService enumService { get; }
        public ICustomerService customerService { get; }
        public ITagService itagService { get; }
        public IPersonnelService personnelService { get; }
        public IGLBDOperationAndTransactionRecordService glbd_OperationAndTransactionRecordService { get; }
        public IMemberTrackService memberTrackService { get; }
        public IBankService  bankService { get; }
    }
}
