using BankUsersApp.Infrastructure.Models;
using BankUsersApp.Infrastructure.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BankUsersApp.Infrastructure.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Banks> Banks { get; set; }
        public DbSet<UserBankDetail> UserBankDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedBanks<Banks>();
            modelBuilder.SeedUsers<Users>();
            modelBuilder.SeedBankUsers<UserBankDetail>();
        }
    }
}
