using BankUsersApp.Infrastructure.DB;
using BankUsersApp.Infrastructure.Models;
using BankUsersApp.Interfaces;

namespace BankUsersApp.Repositories
{
    public class UsersRepo : GenericRepository<Users>, IUsersRepo
    {
        public UsersRepo(ApplicationDbContext context) : base(context)
        {

        }
    }
}
