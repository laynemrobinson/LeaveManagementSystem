using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesandUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39f80ae4-8c55-412b-9b8a-d35f459f9692", null, "Supervisor", "SUPERVISOR" },
                    { "934cd103-601a-462c-afbc-9b34255b2554", null, "Administrator", "ADMINISTRATOR" },
                    { "eec79d06-e0fc-4f1f-9048-f818c845d656", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9d59b512-349d-4f8d-bccc-27c415d74a18", 0, "stamp-admin-user", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEHd2wJjOkSsgCbvCZEi8HtDfrDiP3Cw1traXysvxU4KvG4b1hkVZczvP0lkxYfnkMQ==", null, false, "SECURITYSTAMP", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "934cd103-601a-462c-afbc-9b34255b2554", "9d59b512-349d-4f8d-bccc-27c415d74a18" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39f80ae4-8c55-412b-9b8a-d35f459f9692");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eec79d06-e0fc-4f1f-9048-f818c845d656");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "934cd103-601a-462c-afbc-9b34255b2554", "9d59b512-349d-4f8d-bccc-27c415d74a18" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "934cd103-601a-462c-afbc-9b34255b2554");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d59b512-349d-4f8d-bccc-27c415d74a18");
        }
    }
}
