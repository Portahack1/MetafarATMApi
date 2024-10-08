﻿// <auto-generated />
using System;
using Metafar.ATM.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Metafar.ATM.Persistence.Migrations
{
    [DbContext(typeof(DataBaseService))]
    partial class DataBaseServiceModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Metafar.ATM.Domain.Entities.Account.AccountEntity", b =>
                {
                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Blocked")
                        .HasColumnType("bit");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("FailedLoginAttempts")
                        .HasColumnType("tinyint");

                    b.Property<byte>("MaxLoginAttempts")
                        .HasColumnType("tinyint");

                    b.Property<string>("Pin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AccountNumber");

                    b.HasIndex("UserId");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("Metafar.ATM.Domain.Entities.Transaction.TransactionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TransactionTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccountNumber");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Transaction", (string)null);
                });

            modelBuilder.Entity("Metafar.ATM.Domain.Entities.Transaction.TransactionTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransactionType", (string)null);
                });

            modelBuilder.Entity("Metafar.ATM.Domain.Entities.User.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Metafar.ATM.Domain.Entities.Account.AccountEntity", b =>
                {
                    b.HasOne("Metafar.ATM.Domain.Entities.User.UserEntity", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Metafar.ATM.Domain.Entities.Transaction.TransactionEntity", b =>
                {
                    b.HasOne("Metafar.ATM.Domain.Entities.Account.AccountEntity", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Metafar.ATM.Domain.Entities.Transaction.TransactionTypeEntity", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("Metafar.ATM.Domain.Entities.Account.AccountEntity", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Metafar.ATM.Domain.Entities.User.UserEntity", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
