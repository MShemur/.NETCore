using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore.Migrations
{
    public partial class Family : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {/*
            migrationBuilder.CreateTable(
                name: "IncomeCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutcomeCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutcomeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutcomeTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    TransactionSum = table.Column<double>(nullable: false),
                    Comment = table.Column<string>(maxLength: 200, nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutcomeTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncomeTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    TransactionSum = table.Column<double>(nullable: false),
                    Comment = table.Column<string>(maxLength: 200, nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeTransactions_IncomeCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "IncomeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IncomeCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), "Salary" },
                    { new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"), "Bonus" }
                });

            migrationBuilder.InsertData(
                table: "OutcomeCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"), "Products" },
                    { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), "Clothes" }
                });

            migrationBuilder.InsertData(
                table: "OutcomeTransactions",
                columns: new[] { "Id", "CategoryId", "Comment", "DateTime", "TransactionSum" },
                values: new object[,]
                {
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), "bought shooses", new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), -50.0 },
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"), "bought products", new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), -15.0 }
                });

            migrationBuilder.InsertData(
                table: "IncomeTransactions",
                columns: new[] { "Id", "CategoryId", "Comment", "DateTime", "TransactionSum" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), "Salary for december", new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5000.0 });

            migrationBuilder.InsertData(
                table: "IncomeTransactions",
                columns: new[] { "Id", "CategoryId", "Comment", "DateTime", "TransactionSum" },
                values: new object[] { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), "Salary for november", new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4000.0 });

            migrationBuilder.CreateIndex(
                name: "IX_IncomeTransactions_CategoryId",
                table: "IncomeTransactions",
                column: "CategoryId");
       */

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
