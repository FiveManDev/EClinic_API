﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.ProfileService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ProfileID);
                });

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    RelationshipID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    RelationshipName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.RelationshipID);
                });

            migrationBuilder.CreateTable(
                name: "DoctorProfiles",
                columns: table => new
                {
                    ProfileID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpecializationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quality = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorProfiles", x => x.ProfileID);
                    table.ForeignKey(
                        name: "PK_Profile_One_To_One_DoctorProfile",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ProfileID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupporterProfiles",
                columns: table => new
                {
                    ProfileID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupporterProfiles", x => x.ProfileID);
                    table.ForeignKey(
                        name: "PK_Profile_One_To_One_SupporterProfile",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ProfileID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthProfiles",
                columns: table => new
                {
                    ProfileID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    RelationshipID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthProfiles", x => x.ProfileID);
                    table.ForeignKey(
                        name: "PK_Profile_One_To_One_HealthProfile",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ProfileID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "PK_Relationship_One_To_Many_HealthProfiles",
                        column: x => x.RelationshipID,
                        principalTable: "Relationships",
                        principalColumn: "RelationshipID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "RelationshipID", "RelationshipName" },
                values: new object[] { new Guid("13accb41-1cad-4171-85aa-f3d76464c3dc"), "Me" });

            migrationBuilder.CreateIndex(
                name: "IX_HealthProfiles_RelationshipID",
                table: "HealthProfiles",
                column: "RelationshipID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorProfiles");

            migrationBuilder.DropTable(
                name: "HealthProfiles");

            migrationBuilder.DropTable(
                name: "SupporterProfiles");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
