namespace GodPay_CMS.Repositories.Interfaces
{
    public interface IRepostioryWrapper
    {
        public IUserRepository userRepository { get; }
        public IFuncRepository funcRepository { get; }
        public IFuncClassRepository funcClassRepository { get; }
        public IInsiderRepository insiderRepository { get; }
        public IStoreRepository storeRepository { get; }
        public ICustomerRepository customerRepository { get; }
    }
}
