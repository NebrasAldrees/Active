using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nashet.Data.Migrations
{
    /// <inheritdoc />
    public partial class ByHuda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblClub_tblSite_siteId",
                table: "tblClub");

            migrationBuilder.AlterColumn<int>(
                name: "siteId",
                table: "tblClub",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tblClub_tblSite_siteId",
                table: "tblClub",
                column: "siteId",
                principalTable: "tblSite",
                principalColumn: "SiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblClub_tblSite_siteId",
                table: "tblClub");

            migrationBuilder.AlterColumn<int>(
                name: "siteId",
                table: "tblClub",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblClub_tblSite_siteId",
                table: "tblClub",
                column: "siteId",
                principalTable: "tblSite",
                principalColumn: "SiteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
