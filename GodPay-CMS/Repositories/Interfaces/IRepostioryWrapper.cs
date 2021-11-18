namespace GodPay_CMS.Repositories.Interfaces
{
    public interface IRepostioryWrapper
    {
       public IUserRepository userRepository { get; }
       public IFuncRepository funcRepository { get; }
       public IFuncClassRepository funcClassRepository { get; }
    }
}
