using BankUsersApp.Infrastructure.DB;
using BankUsersApp.Infrastructure.Models;
using BankUsersApp.Interfaces;

namespace BankUsersApp.Repositories
{
    public class BanksRepo : GenericRepository<Banks>, IBanksRepo
    {
        public BanksRepo(ApplicationDbContext context) : base(context)
        {

        }
    }
}
