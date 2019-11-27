using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore.Migrations
{
    public partial class Family : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeTransactions");

            migrationBuilder.DropTable(
                name: "OutcomeCategories");

            migrationBuilder.DropTable(
                name: "OutcomeTransactions");

            migrationBuilder.DropTable(
                name: "IncomeCategories");
        }
    }
}
