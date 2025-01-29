using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleBookCatalog.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAccountFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "UserAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

     
            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "UserAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone_number",
                table: "UserAccounts",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "profile_picture_url",
                table: "UserAccounts",
                type: "nvarchar(max)",
                nullable: true);

   

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "first_name",  "last_name", "phone_number", "profile_picture_url"},
                values: new object[] { null,  null, null, null});

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "first_name",  "last_name", "phone_number", "profile_picture_url"},
                values: new object[] { null,  null, null, null});
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "first_name",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "is_verified",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "last_name",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "phone_number",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "profile_picture_url",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "verification_token",
                table: "UserAccounts");
        }
    }
}
