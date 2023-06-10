﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.PaymentService.Data.Configurations;

#nullable disable

namespace Project.PaymentService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Project.PaymentService.Data.Payment", b =>
                {
                    b.Property<Guid>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("BookingID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OrderID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PaymentAmount")
                        .HasColumnType("float");

                    b.Property<int>("PaymentService")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PaymentID");

                    b.ToTable("Payments", (string)null);
                });

            modelBuilder.Entity("Project.PaymentService.Data.Refund", b =>
                {
                    b.Property<Guid>("RefundID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("PaymentID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("RefundAmount")
                        .HasColumnType("float");

                    b.Property<string>("RefundReason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefundTime")
                        .HasColumnType("datetime2");

                    b.HasKey("RefundID");

                    b.HasIndex("PaymentID")
                        .IsUnique();

                    b.ToTable("Refunds", (string)null);
                });

            modelBuilder.Entity("Project.PaymentService.Data.Refund", b =>
                {
                    b.HasOne("Project.PaymentService.Data.Payment", "Payment")
                        .WithOne("Refund")
                        .HasForeignKey("Project.PaymentService.Data.Refund", "PaymentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PK_Payment_One_To_One_Refund");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Project.PaymentService.Data.Payment", b =>
                {
                    b.Navigation("Refund");
                });
#pragma warning restore 612, 618
        }
    }
}