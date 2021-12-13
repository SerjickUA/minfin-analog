using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinfinAnalog.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Сurrencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сurrencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExchangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SourceCurrencyId = table.Column<int>(type: "int", nullable: true),
                    DestinationCurrencyId = table.Column<int>(type: "int", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(24,6)", precision: 18, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyRates_Сurrencies_DestinationCurrencyId",
                        column: x => x.DestinationCurrencyId,
                        principalTable: "Сurrencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CurrencyRates_Сurrencies_SourceCurrencyId",
                        column: x => x.SourceCurrencyId,
                        principalTable: "Сurrencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExchangeOperationsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SourceCurrencyId = table.Column<int>(type: "int", nullable: true),
                    DestinationCurrencyId = table.Column<int>(type: "int", nullable: true),
                    ExchangeOperationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    BankFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeOperationsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeOperationsHistory_Сurrencies_DestinationCurrencyId",
                        column: x => x.DestinationCurrencyId,
                        principalTable: "Сurrencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExchangeOperationsHistory_Сurrencies_SourceCurrencyId",
                        column: x => x.SourceCurrencyId,
                        principalTable: "Сurrencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExchangeOperationsHistory_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWatchlist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWatchlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWatchlist_Сurrencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Сurrencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserWatchlist_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRates_DestinationCurrencyId",
                table: "CurrencyRates",
                column: "DestinationCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRates_SourceCurrencyId",
                table: "CurrencyRates",
                column: "SourceCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeOperationsHistory_DestinationCurrencyId",
                table: "ExchangeOperationsHistory",
                column: "DestinationCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeOperationsHistory_SourceCurrencyId",
                table: "ExchangeOperationsHistory",
                column: "SourceCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeOperationsHistory_UserId",
                table: "ExchangeOperationsHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWatchlist_CurrencyId",
                table: "UserWatchlist",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWatchlist_UserId",
                table: "UserWatchlist",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyRates");

            migrationBuilder.DropTable(
                name: "ExchangeOperationsHistory");

            migrationBuilder.DropTable(
                name: "UserWatchlist");

            migrationBuilder.DropTable(
                name: "Сurrencies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
