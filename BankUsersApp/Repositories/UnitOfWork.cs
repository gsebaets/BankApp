using BankUsersApp.Infrastructure.DB;
using BankUsersApp.Interfaces;

namespace BankUsersApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            UserRepository = new UsersRepo(_context);
            BankRepository = new BanksRepo(_context);
            UserBankRepository = new UserBankDetailRepo(_context);
        }

        public IUsersRepo UserRepository { get; private set; }
        public IBanksRepo BankRepository { get; private set; }
        public IUserBankDetailRepo UserBankRepository { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
