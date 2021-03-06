﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCore.DbContexts;

namespace NetCore.Migrations
{
    [DbContext(typeof(FamilyBudgetContext))]
    partial class FamilyBudgetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NetCore.Entities.IncomeCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("IncomeCategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                            Name = "Salary"
                        },
                        new
                        {
                            Id = new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                            Name = "Bonus"
                        });
                });

            modelBuilder.Entity("NetCore.Entities.IncomeTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("TransactionSum")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("IncomeTransactions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            CategoryId = new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                            Comment = "Salary for december",
                            DateTime = new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionSum = 5000.0
                        },
                        new
                        {
                            Id = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            CategoryId = new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                            Comment = "Salary for november",
                            DateTime = new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionSum = 4000.0
                        });
                });

            modelBuilder.Entity("NetCore.Entities.OutcomeCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("OutcomeCategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                            Name = "Products"
                        },
                        new
                        {
                            Id = new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                            Name = "Clothes"
                        });
                });

            modelBuilder.Entity("NetCore.Entities.OutcomeTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("TransactionSum")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("OutcomeTransactions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            CategoryId = new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                            Comment = "bought shooses",
                            DateTime = new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionSum = -50.0
                        },
                        new
                        {
                            Id = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                            CategoryId = new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                            Comment = "bought products",
                            DateTime = new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionSum = -15.0
                        });
                });

            modelBuilder.Entity("NetCore.Entities.IncomeTransaction", b =>
                {
                    b.HasOne("NetCore.Entities.IncomeCategory", "Category")
                        .WithMany("IncomeTransactions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
