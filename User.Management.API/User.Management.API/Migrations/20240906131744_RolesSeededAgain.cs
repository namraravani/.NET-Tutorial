using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace User.Management.API.Migrations
{
    /// <inheritdoc />
    public partial class RolesSeededAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7d1378b3-8b60-4a15-b1d4-7debeab5b50d", "1", "Admin", "Admin" },
                    { "9cd5c3c1-1bdd-467d-a2a9-20d44170919f", "3", "HR", "HR" },
                    { "c59913e8-389d-4008-9002-f557a9f1e459", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d1378b3-8b60-4a15-b1d4-7debeab5b50d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cd5c3c1-1bdd-467d-a2a9-20d44170919f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c59913e8-389d-4008-9002-f557a9f1e459");
        }
    }
}
