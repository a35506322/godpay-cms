﻿namespace GodPay_CMS.Services.Interfaces
{
    public interface IServiceWrapper
    {
        public ISigninService signinService { get; }
        public IAuthorityService authorityService { get; }
    }
}
