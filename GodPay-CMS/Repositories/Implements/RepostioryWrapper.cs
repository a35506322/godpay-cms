﻿using GodPay_CMS.Repositories.Interfaces;

namespace GodPay_CMS.Repositories.Implements
{
    public class RepostioryWrapper : IRepostioryWrapper
    {
        private readonly IUserRepository _userRepository;
        private readonly IFuncRepository _funcRepository;
        private readonly IFuncClassRepository _funcClassRepository;

        public RepostioryWrapper(IUserRepository userRepository, IFuncRepository funcRepository, IFuncClassRepository funcClassRepository)
        {
            _userRepository         = userRepository;
            _funcRepository         = funcRepository;
            _funcClassRepository    = funcClassRepository;
        }

        public IUserRepository userRepository => _userRepository;

        public IFuncRepository funcRepository => _funcRepository;

        public IFuncClassRepository funcClassRepository => _funcClassRepository;
    }
}
