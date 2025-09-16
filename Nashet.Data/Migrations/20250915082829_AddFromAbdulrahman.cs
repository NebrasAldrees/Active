using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nashet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFromAbdulrahman : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUser_tblSite_SiteId",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "tblSystemLogs");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tblSystemLogs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "tblSystemLogs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tblSystemLogs");

            migrationBuilder.DropColumn(
                name: "isSent",
                table: "tblSystemLogs");

            migrationBuilder.DropColumn(
                name: "isUpdated",
                table: "tblSite");

            migrationBuilder.AlterColumn<int>(
                name: "SiteId",
                table: "tblUser",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ClubIcon",
                table: "tblClub",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnnouncementImage",
                table: "tblAnnouncement",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tblUser_tblSite_SiteId",
                table: "tblUser",
                column: "SiteId",
                principalTable: "tblSite",
                principalColumn: "SiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUser_tblSite_SiteId",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "ClubIcon",
                table: "tblClub");

            migrationBuilder.AlterColumn<int>(
                name: "SiteId",
                table: "tblUser",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "tblSystemLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tblSystemLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "tblSystemLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tblSystemLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isSent",
                table: "tblSystemLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isUpdated",
                table: "tblSite",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "AnnouncementImage",
                table: "tblAnnouncement",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUser_tblSite_SiteId",
                table: "tblUser",
                column: "SiteId",
                principalTable: "tblSite",
                principalColumn: "SiteId",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
