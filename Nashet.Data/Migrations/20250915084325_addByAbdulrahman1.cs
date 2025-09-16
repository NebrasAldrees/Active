using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nashet.Data.Migrations
{
    /// <inheritdoc />
    public partial class addByAbdulrahman1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserPhone",
                table: "tblUser",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "NameAR",
                table: "tblKFUuser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEN",
                table: "tblKFUuser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "tblKFUuser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPhone",
                table: "tblKFUuser",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAR",
                table: "tblKFUuser");

            migrationBuilder.DropColumn(
                name: "NameEN",
                table: "tblKFUuser");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "tblKFUuser");

            migrationBuilder.DropColumn(
                name: "UserPhone",
                table: "tblKFUuser");

            migrationBuilder.AlterColumn<int>(
                name: "UserPhone",
                table: "tblUser",
                type: "int",
                maxLength: 30,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);
        }
    }
}
