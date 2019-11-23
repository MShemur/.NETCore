using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCore.Entities;

namespace NetCore.DbContexts
{
    public class FamilyBudgetContext : DbContext
    {
        public FamilyBudgetContext(DbContextOptions<FamilyBudgetContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<IncomeTransaction> IncomeTransactions { get; set; }
        public DbSet<OutcomeTransaction> OutcomeTransactions { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }
        public DbSet<OutcomeCategory> OutcomeCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IncomeTransaction>().HasData(
                new IncomeTransaction()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    DateTime = new DateTime(2019, 11, 12),
                    TransactionSum = 5000,
                    Comment = "Salary for december",
                    CategoryId = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05")
                },
                new IncomeTransaction()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    DateTime = new DateTime(2019, 10, 12),
                    TransactionSum = 4000,
                    Comment = "Salary for november",
                    CategoryId = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05")
                }
            );

            modelBuilder.Entity<OutcomeTransaction>().HasData(
                new OutcomeTransaction()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    DateTime = new DateTime(2019, 11, 14),
                    TransactionSum = -50,
                    Comment = "bought shooses",
                    CategoryId = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b")
                },
                new OutcomeTransaction()
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    DateTime = new DateTime(2019, 11, 16),
                    TransactionSum = -15,
                    Comment = "bought products",
                    CategoryId = Guid.Parse("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51")
                }
            );

            modelBuilder.Entity<IncomeCategory>().HasData(
                new IncomeCategory()
                {
                    Id = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    Name = "Salary"
                },
                new IncomeCategory()
                {
                    Id = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                    Name = "Bonus"
                }
            );

            modelBuilder.Entity<OutcomeCategory>().HasData(
                new OutcomeCategory()
                {
                    Id = Guid.Parse("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                    Name = "Products"
                },
                new OutcomeCategory()
                {
                    Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                    Name = "Clothes"
                }
            );
        }
    }
}
