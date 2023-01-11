#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.IdentityService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    RoleID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    TokenID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.TokenID);
                    table.ForeignKey(
                        name: "FK_Tokens_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "CreateAt", "RoleName", "UpdateAt" },
                values: new object[,]
                {
                    { "Ad", new DateTime(2023, 1, 6, 0, 5, 42, 306, DateTimeKind.Local).AddTicks(3077), "Admin", new DateTime(2023, 1, 6, 0, 5, 42, 306, DateTimeKind.Local).AddTicks(3086) },
                    { "Dt", new DateTime(2023, 1, 6, 0, 5, 42, 306, DateTimeKind.Local).AddTicks(3088), "Doctor", new DateTime(2023, 1, 6, 0, 5, 42, 306, DateTimeKind.Local).AddTicks(3089) },
                    { "Sp", new DateTime(2023, 1, 6, 0, 5, 42, 306, DateTimeKind.Local).AddTicks(3087), "Supporter", new DateTime(2023, 1, 6, 0, 5, 42, 306, DateTimeKind.Local).AddTicks(3088) },
                    { "user", new DateTime(2023, 1, 6, 0, 5, 42, 306, DateTimeKind.Local).AddTicks(3089), "User", new DateTime(2023, 1, 6, 0, 5, 42, 306, DateTimeKind.Local).AddTicks(3090) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_UserID",
                table: "Tokens",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
