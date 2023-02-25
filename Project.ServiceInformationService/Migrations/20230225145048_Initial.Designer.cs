﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.ServiceInformationService.Data.Configurations;

#nullable disable

namespace Project.ServiceInformationService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230225145048_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Project.ServiceInformationService.Data.MedicalPackage", b =>
                {
                    b.Property<Guid>("PackageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("EstimatedTime")
                        .HasColumnType("real");

                    b.Property<string>("PackageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<Guid>("SpecializationID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PackageID");

                    b.HasIndex("SpecializationID");

                    b.ToTable("MedicalPackages", (string)null);
                });

            modelBuilder.Entity("Project.ServiceInformationService.Data.Service", b =>
                {
                    b.Property<Guid>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("EstimatedTime")
                        .HasColumnType("real");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalOrder")
                        .HasColumnType("int");

                    b.HasKey("ServiceID");

                    b.ToTable("Services", (string)null);
                });

            modelBuilder.Entity("Project.ServiceInformationService.Data.ServiceItem", b =>
                {
                    b.Property<Guid>("ServiceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PackageID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ServiceID", "PackageID");

                    b.HasIndex("PackageID");

                    b.ToTable("ServiceItems", (string)null);
                });

            modelBuilder.Entity("Project.ServiceInformationService.Data.Specialization", b =>
                {
                    b.Property<Guid>("SpecializationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("SpecializationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpecializationID");

                    b.ToTable("Specializations", (string)null);
                });

            modelBuilder.Entity("Project.ServiceInformationService.Data.MedicalPackage", b =>
                {
                    b.HasOne("Project.ServiceInformationService.Data.Specialization", "Specialization")
                        .WithMany("MedicalPackages")
                        .HasForeignKey("SpecializationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PK_Specialization_One_To_Many_MedicalPackages");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("Project.ServiceInformationService.Data.ServiceItem", b =>
                {
                    b.HasOne("Project.ServiceInformationService.Data.MedicalPackage", "MedicalPackage")
                        .WithMany("ServiceItems")
                        .HasForeignKey("PackageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PK_MedicalPackage_One_To_Many_ServiceItems");

                    b.HasOne("Project.ServiceInformationService.Data.Service", "Service")
                        .WithMany("ServiceItems")
                        .HasForeignKey("ServiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PK_Service_One_To_Many_ServiceItems");

                    b.Navigation("MedicalPackage");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Project.ServiceInformationService.Data.MedicalPackage", b =>
                {
                    b.Navigation("ServiceItems");
                });

            modelBuilder.Entity("Project.ServiceInformationService.Data.Service", b =>
                {
                    b.Navigation("ServiceItems");
                });

            modelBuilder.Entity("Project.ServiceInformationService.Data.Specialization", b =>
                {
                    b.Navigation("MedicalPackages");
                });
#pragma warning restore 612, 618
        }
    }
}
