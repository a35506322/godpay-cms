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

        public RepostioryWrapper(IUserRepository userRepository,
                                IFuncRepository funcRepository, 
                                IFuncClassRepository funcClassRepository, 
                                IInsiderRepository insiderRepository,
                                IStoreRepository storeRepository)
        {
            _userRepository         = userRepository;
            _funcRepository         = funcRepository;
            _funcClassRepository    = funcClassRepository;
            _insiderRepository      = insiderRepository;
            _storeRepository        = storeRepository;
        }

        public IUserRepository userRepository => _userRepository;

        public IFuncRepository funcRepository => _funcRepository;

        public IFuncClassRepository funcClassRepository => _funcClassRepository;

        public IInsiderRepository insiderRepository => _insiderRepository;

        public IStoreRepository storeRepository => _storeRepository;
    }
}
