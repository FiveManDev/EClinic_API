﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.ProfileService.Data.Configurations;

#nullable disable

namespace Project.ProfileService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Project.ProfileService.Data.DoctorProfile", b =>
                {
                    b.Property<Guid>("ProfileID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<Guid>("SpecializationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WorkEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("WorkStart")
                        .HasColumnType("datetime2");

                    b.HasKey("ProfileID");

                    b.ToTable("DoctorProfiles", (string)null);
                });

            modelBuilder.Entity("Project.ProfileService.Data.EmployeeProfile", b =>
                {
                    b.Property<Guid>("ProfileID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WorkEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("WorkStart")
                        .HasColumnType("datetime2");

                    b.HasKey("ProfileID");

                    b.ToTable("EmployeeProfiles", (string)null);
                });

            modelBuilder.Entity("Project.ProfileService.Data.HealthProfile", b =>
                {
                    b.Property<Guid>("ProfileID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BloodType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<Guid>("RelationshipID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("ProfileID");

                    b.HasIndex("RelationshipID");

                    b.ToTable("PatientProfiles", (string)null);
                });

            modelBuilder.Entity("Project.ProfileService.Data.Profile", b =>
                {
                    b.Property<Guid>("ProfileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProfileID");

                    b.ToTable("Profiles", (string)null);
                });

            modelBuilder.Entity("Project.ProfileService.Data.Relationship", b =>
                {
                    b.Property<Guid>("RelationshipID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("RelationshipName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RelationshipID");

                    b.ToTable("Relationships", (string)null);

                    b.HasData(
                        new
                        {
                            RelationshipID = new Guid("13accb41-1cad-4171-85aa-f3d76464c3dc"),
                            RelationshipName = "Me"
                        });
                });

            modelBuilder.Entity("Project.ProfileService.Data.DoctorProfile", b =>
                {
                    b.HasOne("Project.ProfileService.Data.Profile", "Profile")
                        .WithOne("DoctorProfile")
                        .HasForeignKey("Project.ProfileService.Data.DoctorProfile", "ProfileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PK_Profile_One_To_One_DoctorProfile");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Project.ProfileService.Data.EmployeeProfile", b =>
                {
                    b.HasOne("Project.ProfileService.Data.Profile", "Profile")
                        .WithOne("EmployeeProfile")
                        .HasForeignKey("Project.ProfileService.Data.EmployeeProfile", "ProfileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PK_Profile_One_To_One_EmployeeProfile");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Project.ProfileService.Data.HealthProfile", b =>
                {
                    b.HasOne("Project.ProfileService.Data.Profile", "Profile")
                        .WithOne("HealthProfile")
                        .HasForeignKey("Project.ProfileService.Data.HealthProfile", "ProfileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PK_Profile_One_To_One_HealthProfile");

                    b.HasOne("Project.ProfileService.Data.Relationship", "Relationship")
                        .WithMany("HealthProfiles")
                        .HasForeignKey("RelationshipID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PK_Relationship_One_To_Many_HealthProfiles");

                    b.Navigation("Profile");

                    b.Navigation("Relationship");
                });

            modelBuilder.Entity("Project.ProfileService.Data.Profile", b =>
                {
                    b.Navigation("DoctorProfile");

                    b.Navigation("EmployeeProfile");

                    b.Navigation("HealthProfile");
                });

            modelBuilder.Entity("Project.ProfileService.Data.Relationship", b =>
                {
                    b.Navigation("HealthProfiles");
                });
#pragma warning restore 612, 618
        }
    }
}
