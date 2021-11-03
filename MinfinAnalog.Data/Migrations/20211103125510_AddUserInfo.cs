using Microsoft.EntityFrameworkCore.Migrations;

namespace MinfinAnalog.Data.Migrations
{
    public partial class AddUserInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyRates_Сurrencies_CurrencyId",
                table: "CurrencyRates");

            migrationBuilder.DropIndex(
                name: "IX_CurrencyRates_CurrencyId",
                table: "CurrencyRates");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRates_CurrencyId",
                table: "CurrencyRates",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyRates_Сurrencies_CurrencyId",
                table: "CurrencyRates",
                column: "CurrencyId",
                principalTable: "Сurrencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
