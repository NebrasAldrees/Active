using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nashet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblActivity_tblClub_ClubId",
                table: "tblActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_tblTeam_tblClub_ClubId",
                table: "tblTeam");

            migrationBuilder.DropColumn(
                name: "SystemPositionRequest",
                table: "tblActivity");

            migrationBuilder.AlterColumn<int>(
                name: "ClubId",
                table: "tblTeam",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "SiteNameEn",
                table: "tblSite",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SiteNameAR",
                table: "tblSite",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SiteCode",
                table: "tblSite",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClubId",
                table: "tblActivity",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tblActivity_tblClub_ClubId",
                table: "tblActivity",
                column: "ClubId",
                principalTable: "tblClub",
                principalColumn: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblTeam_tblClub_ClubId",
                table: "tblTeam",
                column: "ClubId",
                principalTable: "tblClub",
                principalColumn: "ClubId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblActivity_tblClub_ClubId",
                table: "tblActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_tblTeam_tblClub_ClubId",
                table: "tblTeam");

            migrationBuilder.AlterColumn<int>(
                name: "ClubId",
                table: "tblTeam",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SiteNameEn",
                table: "tblSite",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SiteNameAR",
                table: "tblSite",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SiteCode",
                table: "tblSite",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClubId",
                table: "tblActivity",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SystemPositionRequest",
                table: "tblActivity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_tblActivity_tblClub_ClubId",
                table: "tblActivity",
                column: "ClubId",
                principalTable: "tblClub",
                principalColumn: "ClubId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_tblTeam_tblClub_ClubId",
                table: "tblTeam",
                column: "ClubId",
                principalTable: "tblClub",
                principalColumn: "ClubId",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
