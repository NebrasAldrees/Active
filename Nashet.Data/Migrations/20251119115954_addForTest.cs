using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nashet.Data.Migrations
{
    /// <inheritdoc />
    public partial class addForTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "test",
                table: "tblReport",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "tblKFUuser",
                keyColumn: "KFUUserId",
                keyValue: 1,
                column: "UserType",
                value: "Staff");

            migrationBuilder.UpdateData(
                table: "tblKFUuser",
                keyColumn: "KFUUserId",
                keyValue: 2,
                column: "UserType",
                value: "Student");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "test",
                table: "tblReport");

            migrationBuilder.UpdateData(
                table: "tblKFUuser",
                keyColumn: "KFUUserId",
                keyValue: 1,
                column: "UserType",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "tblKFUuser",
                keyColumn: "KFUUserId",
                keyValue: 2,
                column: "UserType",
                value: "ActivitySupervisor");
        }
    }
}
