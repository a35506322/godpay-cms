using GodPay_CMS.Repositories.Interfaces;

namespace GodPay_CMS.Repositories.Implements
{
    public class RepostioryWrapper : IRepostioryWrapper
    {
        private readonly IUserRepository _userRepository;

        public RepostioryWrapper(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IUserRepository userRepository => _userRepository;
    }
}
