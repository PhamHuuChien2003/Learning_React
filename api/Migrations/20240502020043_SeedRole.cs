using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f2f1494-2a3e-4fba-bece-bc652afd63bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb3a56f9-aaeb-4734-8a4d-d6145a96b6c2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6f3a838c-10a2-48e9-be39-ef3e59cc9c69", null, "Admin", "ADMIN" },
                    { "94d838ee-7620-4df8-b49b-dbe582903fe2", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "9f2f1494-2a3e-4fba-bece-bc652afd63bf", null, "Admin", "ADMIN" },
                    { "bb3a56f9-aaeb-4734-8a4d-d6145a96b6c2", null, "User", "USER" }
                });
        }
    }
}
