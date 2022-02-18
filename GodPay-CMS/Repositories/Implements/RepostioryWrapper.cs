using GodPay_CMS.Repositories.Interfaces;

namespace GodPay_CMS.Repositories.Implements
{
    public class RepostioryWrapper : IRepostioryWrapper
    {
        private readonly IUserRepository _userRepository;
        private readonly IFuncRepository _funcRepository;
        private readonly IFuncClassRepository _funcClassRepository;
        private readonly IInsiderRepository _insiderRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPersonnelRepository _personnelRepository;
        private readonly IBankDetailRepository _bankDetailRepository;

        public RepostioryWrapper(IUserRepository userRepository,
                                IFuncRepository funcRepository,
                                IFuncClassRepository funcClassRepository,
                                IInsiderRepository insiderRepository,
                                IStoreRepository storeRepository,
                                ICustomerRepository customerRepository,
                                IPersonnelRepository personnelRepository,
                                IBankDetailRepository bankDetailRepository)
        {
            _userRepository = userRepository;
            _funcRepository = funcRepository;
            _funcClassRepository = funcClassRepository;
            _insiderRepository = insiderRepository;
            _storeRepository = storeRepository;
            _customerRepository = customerRepository;
            _personnelRepository = personnelRepository;
            _bankDetailRepository = bankDetailRepository;
        }

        public IUserRepository userRepository => _userRepository;

        public IFuncRepository funcRepository => _funcRepository;

        public IFuncClassRepository funcClassRepository => _funcClassRepository;

        public IInsiderRepository insiderRepository => _insiderRepository;

        public IStoreRepository storeRepository => _storeRepository;

        public ICustomerRepository customerRepository => _customerRepository;

        public IPersonnelRepository personnelRepository => _personnelRepository;

        public IBankDetailRepository bankDetailRepository => _bankDetailRepository;
    }
}
