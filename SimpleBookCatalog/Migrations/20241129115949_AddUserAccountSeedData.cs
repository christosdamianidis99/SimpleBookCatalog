using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleBookCatalog.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAccountSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "id", "password", "role", "user_name" },
                values: new object[,]
                {
                    { 1, "admin123", "Administrator", "admin" },
                    { 2, "user123", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
