using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankUsersApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BankId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "UserBankDetail",
                columns: table => new
                {
                    UserBankDetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BankId = table.Column<long>(type: "bigint", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBankDetail", x => x.UserBankDetailId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    ResidentialAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankId", "AddedOn", "BankName", "Status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8187), "FNB", true },
                    { 2L, new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8198), "Capitec", true },
                    { 3L, new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8199), "Netbank", true }
                });

            migrationBuilder.InsertData(
                table: "UserBankDetail",
                columns: new[] { "UserBankDetailId", "AccountNumber", "AccountType", "AddedOn", "AvailableBalance", "BankId", "Status", "UserId" },
                values: new object[,]
                {
                    { 1L, "427560404", "Cheque", new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8446), 5000.00m, 1L, true, 1L },
                    { 4L, "368475743", "Cheque", new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8469), 7000.00m, 2L, true, 2L },
                    { 5L, "359163664", "Savings", new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8473), 15000.00m, 3L, true, 2L },
                    { 6L, "100938456", "Savings", new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8478), 9000.00m, 1L, true, 3L },
                    { 8L, "410465792", "Savings", new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8480), 6000.00m, 1L, true, 4L },
                    { 9L, "483105399", "Cheque", new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8488), 12000.00m, 3L, true, 4L },
                    { 10L, "346645962", "Cheque", new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8491), 8000.00m, 1L, true, 5L },
                    { 11L, "493682017", "Fixed Deposit", new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8495), 30000.00m, 2L, true, 5L },
                    { 12L, "346399646", "Cheque", new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8499), 6500.00m, 2L, true, 6L },
                    { 13L, "664869602", "Savings", new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8505), 11000.00m, 3L, true, 6L },
                    { 14L, "949732954", "Cheque", new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8508), 4000.00m, 1L, true, 7L },
                    { 15L, "323277976", "Savings", new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8511), 9500.00m, 2L, true, 8L },
                    { 16L, "421648190", "Cheque", new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8602), 5500.00m, 3L, true, 9L },
                    { 17L, "895261861", "Fixed Deposit", new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8608), 18000.00m, 1L, true, 10L }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AddedOn", "DateOfBirth", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "Password", "ResidentialAddress", "Status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8350), new DateTime(1987, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "TomasDDavis@dayrep.com", "Tomas", "8708139333082", "Davis", "27833653254", "password1", "1626 Prospect St Laudium 0037", true },
                    { 2L, new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8353), new DateTime(1995, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "LuzCGillespie@dayrep.com", "Luz", "9507241481188", "Gillespie", "27828566711", "password2", "1342 Sandown Rd Cape Town 8002", true },
                    { 3L, new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8355), new DateTime(1953, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "JeanJMasters@rhyta.com", "Jean", "5308284995083", "Masters", "27842302921", "password3", "334 Daffodil Dr Mqanduli 5085", true },
                    { 4L, new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8361), new DateTime(1944, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "MelissaCHennigan@teleworm.us", "Melissa", "4411110823080", "Hennigan", "27836601180", "password4", "772 North Street Utrecht 2980", true },
                    { 5L, new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8362), new DateTime(1963, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "JoshuaLRohrer@armyspy.com", "Joshua", "6304128535184", "Rohrer", "27849978318", "password5", "577 Gray Pl Durban 4061", true },
                    { 6L, new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8364), new DateTime(1983, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "NathanielPOlson@armyspy.com", "Nathaniel", "8312107886088", "Olson", "27842399367", "password6", "570 Gemsbok St Pietersburg 0780", true },
                    { 7L, new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8366), new DateTime(2001, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "RebeccaJMack@armyspy.com", "Rebecca", "106064473080", "Mack", "27839078572", "password7", "995 Loop St Hopefield 7355 Curious ", true },
                    { 8L, new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8368), new DateTime(1972, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "ErvinDRandolph@dayrep.com", "Ervin", "7201255800085", "Randolph", "27824672109", "password8", "349 Old Cres Indwe 5445", true },
                    { 9L, new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8370), new DateTime(1938, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "EmikoRSloan@armyspy.com", "Emiko", "3807210295080", "Sloan", "27843555547", "password9", "297 Glyn St Silverton 0170", true },
                    { 10L, new DateTime(2023, 6, 30, 18, 1, 49, 93, DateTimeKind.Local).AddTicks(8371), new DateTime(1939, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "MichaelRShew@teleworm.us", "Michael", "3910139902180", "Shew", "27833368984", "password10", "1747 Impala St Dalton 3242", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "UserBankDetail");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
