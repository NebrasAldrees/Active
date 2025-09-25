using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nashet.Data.Migrations
{
    /// <inheritdoc />
    public partial class SAFA : Migration
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
                name: "StudentSkills",
                table: "tblStudent",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentPhone",
                table: "tblStudent",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "StudentNameEn",
                table: "tblStudent",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentNameAr",
                table: "tblStudent",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentEmail",
                table: "tblStudent",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AcademicId",
                table: "tblStudent",
                type: "nvarchar(10)",
                maxLength: 10,
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

            migrationBuilder.AddColumn<string>(
                name: "ClubOverview",
                table: "tblClub",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClubNameAR",
                table: "tblAnnouncement",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "siteId",
                table: "tblAnnouncement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ClubId",
                table: "tblActivity",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_tblAnnouncement_siteId",
                table: "tblAnnouncement",
                column: "siteId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblActivity_tblClub_ClubId",
                table: "tblActivity",
                column: "ClubId",
                principalTable: "tblClub",
                principalColumn: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblAnnouncement_tblSite_siteId",
                table: "tblAnnouncement",
                column: "siteId",
                principalTable: "tblSite",
                principalColumn: "SiteId",
                onDelete: ReferentialAction.NoAction);

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
                name: "FK_tblAnnouncement_tblSite_siteId",
                table: "tblAnnouncement");

            migrationBuilder.DropForeignKey(
                name: "FK_tblTeam_tblClub_ClubId",
                table: "tblTeam");

            migrationBuilder.DropIndex(
                name: "IX_tblAnnouncement_siteId",
                table: "tblAnnouncement");

            migrationBuilder.DropColumn(
                name: "ClubOverview",
                table: "tblClub");

            migrationBuilder.DropColumn(
                name: "ClubNameAR",
                table: "tblAnnouncement");

            migrationBuilder.DropColumn(
                name: "siteId",
                table: "tblAnnouncement");

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
                name: "StudentSkills",
                table: "tblStudent",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentPhone",
                table: "tblStudent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentNameEn",
                table: "tblStudent",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentNameAr",
                table: "tblStudent",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentEmail",
                table: "tblStudent",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AcademicId",
                table: "tblStudent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
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
