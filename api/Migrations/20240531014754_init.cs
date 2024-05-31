using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f3a838c-10a2-48e9-be39-ef3e59cc9c69");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94d838ee-7620-4df8-b49b-dbe582903fe2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54a5800a-57e1-4cf4-acd2-d5526f23d30f", null, "User", "USER" },
                    { "d3c56b31-1d57-47e4-b217-7e16fd50f463", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54a5800a-57e1-4cf4-acd2-d5526f23d30f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3c56b31-1d57-47e4-b217-7e16fd50f463");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6f3a838c-10a2-48e9-be39-ef3e59cc9c69", null, "Admin", "ADMIN" },
                    { "94d838ee-7620-4df8-b49b-dbe582903fe2", null, "User", "USER" }
                });
        }
    }
}
