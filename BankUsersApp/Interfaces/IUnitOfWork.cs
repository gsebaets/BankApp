

namespace BankUsersApp.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUsersRepo UserRepository { get; }
        IBanksRepo BankRepository { get; }
        IUserBankDetailRepo UserBankRepository { get; }
        int Complete();
    }
}
