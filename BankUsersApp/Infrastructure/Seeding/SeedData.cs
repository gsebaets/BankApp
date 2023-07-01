using BankUsersApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BankUsersApp.Infrastructure.Seeding
{
    public static class SeedData 
    {
        public static ModelBuilder SeedBanks<T>(this ModelBuilder modelBuilder) where T : Banks
        {
            // Seed data for Banks model
            modelBuilder.Entity<Banks>().HasData(new Banks[]
            {
                new Banks { BankId = 1, BankName = "FNB", Status = true, AddedOn = DateTime.Now },
                new Banks { BankId = 2, BankName = "Capitec", Status = true, AddedOn = DateTime.Now },
                new Banks { BankId = 3, BankName = "Netbank", Status = true, AddedOn = DateTime.Now },
                // Add more seed data for Banks as needed
            });
            return modelBuilder;
        }

        public static ModelBuilder SeedUsers<T>(this ModelBuilder modelBuilder) where T : Users
        {
            // Seed data for Users model
            modelBuilder.Entity<Users>().HasData(new Users[]
            {
                new Users
                {
                    UserId = 1,
                    FirstName = "Tomas",
                    LastName = "Davis",
                    DateOfBirth = new DateTime(1987, 8, 13),
                    IdNumber = "8708139333082",
                    ResidentialAddress = "1626 Prospect St Laudium 0037",
                    MobileNumber = "27833653254",
                    Email = "TomasDDavis@dayrep.com",
                    Password = "password1",
                    Status = true,
                    AddedOn = DateTime.Now
                },
                new Users
                {
                    UserId = 2,
                    FirstName = "Luz",
                    LastName = "Gillespie",
                    DateOfBirth = new DateTime(1995, 7, 24),
                    IdNumber = "9507241481188",
                    ResidentialAddress = "1342 Sandown Rd Cape Town 8002",
                    MobileNumber = "27828566711",
                    Email = "LuzCGillespie@dayrep.com",
                    Password = "password2",
                    Status = true,
                    AddedOn = DateTime.Now
                },
                new Users
                {
                    UserId = 3,
                    FirstName = "Jean",
                    LastName = "Masters",
                    DateOfBirth = new DateTime(1953, 8, 28),
                    IdNumber = "5308284995083",
                    ResidentialAddress = "334 Daffodil Dr Mqanduli 5085",
                    MobileNumber = "27842302921",
                    Email = "JeanJMasters@rhyta.com",
                    Password = "password3",
                    Status = true,
                    AddedOn = DateTime.Now
                },
                new Users
                {
                    UserId = 4,
                    FirstName = "Melissa",
                    LastName = "Hennigan",
                    DateOfBirth = new DateTime(1944, 11, 11),
                    IdNumber = "4411110823080",
                    ResidentialAddress = "772 North Street Utrecht 2980",
                    MobileNumber = "27836601180",
                    Email = "MelissaCHennigan@teleworm.us",
                    Password = "password4",
                    Status = true,
                    AddedOn = DateTime.Now
                },
                new Users
                {
                    UserId = 5,
                    FirstName = "Joshua",
                    LastName = "Rohrer",
                    DateOfBirth = new DateTime(1963, 4, 12),
                    IdNumber = "6304128535184",
                    ResidentialAddress = "577 Gray Pl Durban 4061",
                    MobileNumber = "27849978318",
                    Email = "JoshuaLRohrer@armyspy.com",
                    Password = "password5",
                    Status = true,
                    AddedOn = DateTime.Now
                },
                new Users
                {
                    UserId = 6,
                    FirstName = "Nathaniel",
                    LastName = "Olson",
                    DateOfBirth = new DateTime(1983, 12, 10),
                    IdNumber = "8312107886088",
                    ResidentialAddress = "570 Gemsbok St Pietersburg 0780",
                    MobileNumber = "27842399367",
                    Email = "NathanielPOlson@armyspy.com",
                    Password = "password6",
                    Status = true,
                    AddedOn = DateTime.Now
                },
                new Users
                {
                    UserId = 7,
                    FirstName = "Rebecca",
                    LastName = "Mack",
                    DateOfBirth = new DateTime(2001, 6, 6),
                    IdNumber = "106064473080",
                    ResidentialAddress = "995 Loop St Hopefield 7355 Curious ",
                    MobileNumber = "27839078572",
                    Email = "RebeccaJMack@armyspy.com",
                    Password = "password7",
                    Status = true,
                    AddedOn = DateTime.Now
                },
                new Users
                {
                    UserId = 8,
                    FirstName = "Ervin",
                    LastName = "Randolph",
                    DateOfBirth = new DateTime(1972, 1, 25),
                    IdNumber = "7201255800085",
                    ResidentialAddress = "349 Old Cres Indwe 5445",
                    MobileNumber = "27824672109",
                    Email = "ErvinDRandolph@dayrep.com",
                    Password = "password8",
                    Status = true,
                    AddedOn = DateTime.Now
                },
                new Users
                {
                    UserId = 9,
                    FirstName = "Emiko",
                    LastName = "Sloan",
                    DateOfBirth = new DateTime(1938, 7, 21),
                    IdNumber = "3807210295080",
                    ResidentialAddress = "297 Glyn St Silverton 0170",
                    MobileNumber = "27843555547",
                    Email = "EmikoRSloan@armyspy.com",
                    Password = "password9",
                    Status = true,
                    AddedOn = DateTime.Now
                },
                new Users
                {
                    UserId = 10,
                    FirstName = "Michael",
                    LastName = "Shew",
                    DateOfBirth = new DateTime(1939, 10, 13),
                    IdNumber = "3910139902180",
                    ResidentialAddress = "1747 Impala St Dalton 3242",
                    MobileNumber = "27833368984",
                    Email = "MichaelRShew@teleworm.us",
                    Password = "password10",
                    Status = true,
                    AddedOn = DateTime.Now
                }
            });
            return modelBuilder;
        }

        public static ModelBuilder SeedBankUsers<T>(this ModelBuilder modelBuilder) where T : UserBankDetail
        {
            // Seed data for UserBankDetail model
            modelBuilder.Entity<UserBankDetail>().HasData(new List<UserBankDetail>
            {
                // User 1 - Tomas Davis
                new UserBankDetail
                {
                    UserBankDetailId = 1,
                    UserId = 1,
                    BankId = 1,
                    AccountType = "Cheque",
                    AccountNumber = GenerateAccountNumber(),
                    AvailableBalance = 5000.00m,
                    AddedOn = DateTime.Now,
                    Status = true
                },

                // User 2 - Luz Gillespie
                new UserBankDetail
                {
                    UserBankDetailId = 4,
                    UserId = 2,
                    BankId = 2,
                    AccountType = "Cheque",
                    AccountNumber = GenerateAccountNumber(),
                    AvailableBalance = 7000.00m,
                    AddedOn = DateTime.Now,
                    Status = true
                },

                new UserBankDetail
                {
                    UserBankDetailId = 5,
                    UserId = 2,
                    BankId = 3,
                    AccountType = "Savings",
                    AccountNumber = GenerateAccountNumber(),
                    AvailableBalance = 15000.00m,
                    AddedOn = DateTime.Now,
                    Status = true
                },

                // User 3 - Jean Masters
                new UserBankDetail
                {
                    UserBankDetailId = 6,
                    UserId = 3,
                    BankId = 1,
                    AccountType = "Savings",
                    AccountNumber = GenerateAccountNumber(),
                    AvailableBalance = 9000.00m,
                    AddedOn = DateTime.Now,
                    Status = true
                },

                // User 4 - Melissa Hennigan
                new UserBankDetail
                {
                    UserBankDetailId = 8,
                    UserId = 4,
                    BankId = 1,
                    AccountType = "Savings",
                    AccountNumber = GenerateAccountNumber(),
                    AvailableBalance = 6000.00m,
                    AddedOn = DateTime.Now,
                    Status = true
                },

                new UserBankDetail
                {
                    UserBankDetailId = 9,
                    UserId = 4,
                    BankId = 3,
                    AccountType = "Cheque",
                    AccountNumber = GenerateAccountNumber(),
                    AvailableBalance = 12000.00m,
                    AddedOn = DateTime.Now,
                    Status = true
                },

                // User 5 - Joshua Rohrer
                new UserBankDetail
                {
                    UserBankDetailId = 10,
                    UserId = 5,
                    BankId = 1,
                    AccountType = "Cheque",
                    AccountNumber = GenerateAccountNumber(),
                    AvailableBalance = 8000.00m,
                    AddedOn = DateTime.Now,
                    Status = true
                },

                new UserBankDetail
                {
                    UserBankDetailId = 11,
                    UserId = 5,
                    BankId = 2,
                    AccountType = "Fixed Deposit",
                    AccountNumber = GenerateAccountNumber(),
                    AvailableBalance = 30000.00m,
                    AddedOn = DateTime.Now,
                    Status = true
                },

                // User 6 - Nathaniel Olson
                new UserBankDetail
                {
                    UserBankDetailId = 12,
                    UserId = 6,
                    BankId = 2,
                    AccountType = "Cheque",
                    AccountNumber = GenerateAccountNumber(),
                    AvailableBalance = 6500.00m,
                    AddedOn = DateTime.Now,
                    Status = true
                },

                new UserBankDetail
                {
                    UserBankDetailId = 13,
                    UserId = 6,
                    BankId = 3,
                    AccountType = "Savings",
                    AccountNumber = GenerateAccountNumber(),
                    AvailableBalance = 11000.00m,
                    AddedOn = DateTime.Now,
                    Status = true
                },

                // User 7 - Rebecca Mack
                new UserBankDetail
                {
                    UserBankDetailId = 14,
                    UserId = 7,
                    BankId = 1,
                    AccountType = "Cheque",
                    AccountNumber = GenerateAccountNumber(),
                    AvailableBalance = 4000.00m,
                    AddedOn = DateTime.Now,
                    Status = true
                },

                // User 8 - Ervin Randolph
                new UserBankDetail
                {
                    UserBankDetailId = 15,
                    UserId = 8,
                    BankId = 2,
                    AccountType = "Savings",
                    AccountNumber = GenerateAccountNumber(),
                    AvailableBalance = 9500.00m,
                    AddedOn = DateTime.Now,
                    Status = true
                },

                // User 9 - Emiko Sloan
                new UserBankDetail
                {
                    UserBankDetailId = 16,
                    UserId = 9,
                    BankId = 3,
                    AccountType = "Cheque",
                    AccountNumber = GenerateAccountNumber(),
                    AvailableBalance = 5500.00m,
                    AddedOn = DateTime.Now,
                    Status = true
                },

                // User 10 - Michael Shew
                new UserBankDetail
                {
                    UserBankDetailId = 17,
                    UserId = 10,
                    BankId = 1,
                    AccountType = "Fixed Deposit",
                    AccountNumber = GenerateAccountNumber(),
                    AvailableBalance = 18000.00m,
                    AddedOn = DateTime.Now,
                    Status = true
                }
            });
            return modelBuilder;
        }

        private static string GenerateAccountNumber()
        {
            // Generate a random account number of 10 digits
            var random = new Random();
            var accountNumber = random.Next(100000000, 999999999).ToString();
            return accountNumber;
        }
    }
}
