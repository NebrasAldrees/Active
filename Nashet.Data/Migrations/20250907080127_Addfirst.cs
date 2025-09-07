using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nashet.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addfirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblClubRole",
                columns: table => new
                {
                    ClubRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClubRole", x => x.ClubRoleId);
                });

            migrationBuilder.CreateTable(
                name: "tblEmailNotificationLog",
                columns: table => new
                {
                    EmailNotificationsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmailNotificationLog", x => x.EmailNotificationsId);
                });

            migrationBuilder.CreateTable(
                name: "tblKFUuser",
                columns: table => new
                {
                    KFUUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblKFUuser", x => x.KFUUserId);
                });

            migrationBuilder.CreateTable(
                name: "tblSite",
                columns: table => new
                {
                    SiteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteCode = table.Column<int>(type: "int", nullable: false),
                    SiteNameAR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SiteNameEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isUpdated = table.Column<bool>(type: "bit", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSite", x => x.SiteId);
                });

            migrationBuilder.CreateTable(
                name: "tblSystemNotification",
                columns: table => new
                {
                    SystemNotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSystemNotification", x => x.SystemNotificationId);
                });

            migrationBuilder.CreateTable(
                name: "tblSystemRole",
                columns: table => new
                {
                    SystemRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSystemRole", x => x.SystemRoleId);
                });

            migrationBuilder.CreateTable(
                name: "tblClub",
                columns: table => new
                {
                    ClubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    siteId = table.Column<int>(type: "int", nullable: false),
                    ClubNameAR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClubNameEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClubVision = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClub", x => x.ClubId);
                    table.ForeignKey(
                        name: "FK_tblClub_tblSite_siteId",
                        column: x => x.siteId,
                        principalTable: "tblSite",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tblStudent",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicId = table.Column<int>(type: "int", nullable: false),
                    StudentNameAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StudentNameEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StudentEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StudentPhone = table.Column<int>(type: "int", nullable: false),
                    SiteId = table.Column<int>(type: "int", nullable: false),
                    StudentSkills = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStudent", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_tblStudent_tblSite_SiteId",
                        column: x => x.SiteId,
                        principalTable: "tblSite",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tblUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemRoleId = table.Column<int>(type: "int", nullable: false),
                    UserNameAR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserNameEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserPhone = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    SiteId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_tblUsers_tblSite_SiteId",
                        column: x => x.SiteId,
                        principalTable: "tblSite",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tblUsers_tblSystemRole_SystemRoleId",
                        column: x => x.SystemRoleId,
                        principalTable: "tblSystemRole",
                        principalColumn: "SystemRoleId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tblActivity",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    ActivityTopic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActivityDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ActivityStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivityEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivityTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivityLocation = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ActivityPoster = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblActivity", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_tblActivity_tblClub_ClubId",
                        column: x => x.ClubId,
                        principalTable: "tblClub",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tblAnnouncement",
                columns: table => new
                {
                    AnnouncementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    AnnouncementType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AnnouncementTopic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AnnouncementDetails = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AnnouncementImage = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAnnouncement", x => x.AnnouncementId);
                    table.ForeignKey(
                        name: "FK_tblAnnouncement_tblClub_ClubId",
                        column: x => x.ClubId,
                        principalTable: "tblClub",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tblReport",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Path = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsAdded = table.Column<bool>(type: "bit", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblReport", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_tblReport_tblClub_ClubId",
                        column: x => x.ClubId,
                        principalTable: "tblClub",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tblTeam",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    TeamNameAR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TeamNameEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTeam", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_tblTeam_tblClub_ClubId",
                        column: x => x.ClubId,
                        principalTable: "tblClub",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tblSystemLogs",
                columns: table => new
                {
                    LogsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Table = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    RecordId = table.Column<int>(type: "int", nullable: false),
                    operation_type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    operation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NewValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    other_details = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSystemLogs", x => x.LogsId);
                    table.ForeignKey(
                        name: "FK_tblSystemLogs_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tblMembership",
                columns: table => new
                {
                    MembershipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ClubRoleId = table.Column<int>(type: "int", nullable: false),
                    TeameId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMembership", x => x.MembershipId);
                    table.ForeignKey(
                        name: "FK_tblMembership_tblClubRole_ClubRoleId",
                        column: x => x.ClubRoleId,
                        principalTable: "tblClubRole",
                        principalColumn: "ClubRoleId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tblMembership_tblStudent_StudentId",
                        column: x => x.StudentId,
                        principalTable: "tblStudent",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tblMembership_tblTeam_TeamId",
                        column: x => x.TeamId,
                        principalTable: "tblTeam",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblActivity_ClubId",
                table: "tblActivity",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAnnouncement_ClubId",
                table: "tblAnnouncement",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_tblClub_siteId",
                table: "tblClub",
                column: "siteId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMembership_ClubRoleId",
                table: "tblMembership",
                column: "ClubRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMembership_StudentId",
                table: "tblMembership",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMembership_TeamId",
                table: "tblMembership",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReport_ClubId",
                table: "tblReport",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_tblStudent_SiteId",
                table: "tblStudent",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSystemLogs_UserId",
                table: "tblSystemLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTeam_ClubId",
                table: "tblTeam",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUsers_SiteId",
                table: "tblUsers",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUsers_SystemRoleId",
                table: "tblUsers",
                column: "SystemRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblActivity");

            migrationBuilder.DropTable(
                name: "tblAnnouncement");

            migrationBuilder.DropTable(
                name: "tblEmailNotificationLog");

            migrationBuilder.DropTable(
                name: "tblKFUuser");

            migrationBuilder.DropTable(
                name: "tblMembership");

            migrationBuilder.DropTable(
                name: "tblReport");

            migrationBuilder.DropTable(
                name: "tblSystemLogs");

            migrationBuilder.DropTable(
                name: "tblSystemNotification");

            migrationBuilder.DropTable(
                name: "tblClubRole");

            migrationBuilder.DropTable(
                name: "tblStudent");

            migrationBuilder.DropTable(
                name: "tblTeam");

            migrationBuilder.DropTable(
                name: "tblUsers");

            migrationBuilder.DropTable(
                name: "tblClub");

            migrationBuilder.DropTable(
                name: "tblSystemRole");

            migrationBuilder.DropTable(
                name: "tblSite");
        }
    }
}
