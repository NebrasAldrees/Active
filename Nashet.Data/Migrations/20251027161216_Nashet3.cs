using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nashet.Data.Migrations
{
    /// <inheritdoc />
    public partial class Nashet3 : Migration
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
                    RoleTypeAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RoleTypeEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    NameAR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NameEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserPhone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
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
                    SiteCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SiteNameAR = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SiteNameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    RoleTypeAr = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    RoleTypeEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    ClubOverview = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ClubIcon = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblStudent",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    StudentNameAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    StudentNameEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    StudentEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    StudentPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SiteId = table.Column<int>(type: "int", nullable: false),
                    StudentSkills = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemRoleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemRoleId = table.Column<int>(type: "int", nullable: true),
                    UserNameAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserNameEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserPhone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SystemROles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteId = table.Column<int>(type: "int", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_tblUser_tblSite_SiteId",
                        column: x => x.SiteId,
                        principalTable: "tblSite",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblUser_tblSystemRole_SystemRoleId",
                        column: x => x.SystemRoleId,
                        principalTable: "tblSystemRole",
                        principalColumn: "SystemRoleId",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblAnnouncement",
                columns: table => new
                {
                    AnnouncementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    AnnouncementType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AnnouncementTopic = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AnnouncementDetails = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AnnouncementImage = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblReport",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubId = table.Column<int>(type: "int", nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblTeam",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubId = table.Column<int>(type: "int", nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblActivityRequest",
                columns: table => new
                {
                    ARId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    SiteID = table.Column<int>(type: "int", nullable: true),
                    ClubID = table.Column<int>(type: "int", nullable: true),
                    ActivityTopic = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ActivityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivityTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    ActivityLocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ActivityPoster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityRequestId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblActivityRequest", x => x.ARId);
                    table.ForeignKey(
                        name: "FK_tblActivityRequest_tblClub_ClubID",
                        column: x => x.ClubID,
                        principalTable: "tblClub",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblActivityRequest_tblSite_SiteID",
                        column: x => x.SiteID,
                        principalTable: "tblSite",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblActivityRequest_tblUser_UserID",
                        column: x => x.UserID,
                        principalTable: "tblUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
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
                    other_details = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSystemLogs", x => x.LogsId);
                    table.ForeignKey(
                        name: "FK_tblSystemLogs_tblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblMembership",
                columns: table => new
                {
                    MembershipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    ClubRoleId = table.Column<int>(type: "int", nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblMembership_tblStudent_StudentId",
                        column: x => x.StudentId,
                        principalTable: "tblStudent",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblMembership_tblTeam_TeamId",
                        column: x => x.TeamId,
                        principalTable: "tblTeam",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblMembershipRequest",
                columns: table => new
                {
                    MRId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: true),
                    ClubID = table.Column<int>(type: "int", nullable: true),
                    TeamID = table.Column<int>(type: "int", nullable: true),
                    RequestTeam1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RequestTeam2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RequestTeam3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RequestReason = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMembershipRequest", x => x.MRId);
                    table.ForeignKey(
                        name: "FK_TblMembershipRequest_tblClub_ClubID",
                        column: x => x.ClubID,
                        principalTable: "tblClub",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMembershipRequest_tblStudent_StudentID",
                        column: x => x.StudentID,
                        principalTable: "tblStudent",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMembershipRequest_tblTeam_TeamID",
                        column: x => x.TeamID,
                        principalTable: "tblTeam",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblPositionRequest",
                columns: table => new
                {
                    PRId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembershipID = table.Column<int>(type: "int", nullable: true),
                    ClubRoleID = table.Column<int>(type: "int", nullable: true),
                    RequestedPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SystemPositionRequest = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPositionRequest", x => x.PRId);
                    table.ForeignKey(
                        name: "FK_tblPositionRequest_tblClubRole_ClubRoleID",
                        column: x => x.ClubRoleID,
                        principalTable: "tblClubRole",
                        principalColumn: "ClubRoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPositionRequest_tblMembership_MembershipID",
                        column: x => x.MembershipID,
                        principalTable: "tblMembership",
                        principalColumn: "MembershipId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "tblKFUuser",
                columns: new[] { "KFUUserId", "CreationDate", "Guid", "IsActive", "IsDeleted", "NameAR", "NameEN", "Password", "UserEmail", "UserPhone", "UserType", "Username", "isSent" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("7f4a5d58-29db-411b-8e3e-dcf0918e5dc7"), true, false, "منتهى", "Muntaha", "Muntaha", "Muntaha@gmail.com", "0536763284", "Admin", "Muntaha_12", true },
                    { 2, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("9ba46550-b007-48cf-9f21-bc473d2b4393"), true, false, "هدى", "Huda", "Huda", "Huda@gmail.com", "0533924794", "Activities Supervisor", "Huda1", true },
                    { 3, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("08d5ea5b-4216-40d6-b166-53c4dfa363e7"), true, false, "نبراس", "Nebras", "Nebras", "Nebras@gmail.com", "0540345575", "Student", "Nebras2", true }
                });

            migrationBuilder.InsertData(
                table: "tblSite",
                columns: new[] { "SiteId", "CreationDate", "Guid", "IsActive", "IsDeleted", "SiteCode", "SiteNameAR", "SiteNameEn", "isSent" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("9b7c9604-e3f3-40a4-9015-9916b7cabcff"), true, false, "0920", "كلية علوم الحاسب وتقنية المعلومات", "College of Computer Science and Information Technology", true },
                    { 2, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("8f4336da-ea19-4019-8090-5a6cf70dbf49"), true, false, "0940", "كلية الهندسة", "College of Engineering", true },
                    { 3, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("cc83caab-60ec-4781-a2fc-0cae1217f7fc"), true, false, "0950", "كلية الصيدلة الإكلينيكية", "College of Clinical Pharmacy", true },
                    { 4, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("332f3a58-9aa3-4898-8f29-ff832149c240"), true, false, "0960", "كلية العلوم الطبية", "College of Applied Medical Sciences", true },
                    { 5, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("0fe1af63-f72e-402e-b0b1-87013f4c06b9"), true, false, "0300", "كلية العلوم", "College of Science", true },
                    { 6, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("4516c8da-9634-4cf6-bfe7-eaa2f1dc5c29"), true, false, "0310", "كلية الطب", "College of Medicine", true },
                    { 7, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("37dba4ea-1caa-4c81-a022-e00e17ec2ebd"), true, false, "0320", "كلية الحقوق", "College of Law", true },
                    { 8, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("2110b192-c071-484b-9d03-035ec84f2e9d"), true, false, "0340", "كلية العلوم الزراعية والتغذية", "College of Agricultural Science and Nutrition", true },
                    { 9, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("4646924f-08b9-4e80-9bab-2318eade4917"), true, false, "2200", "كلية الاداب", "College of Arts", true },
                    { 10, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("fbf9fe3e-45e3-40cf-881c-0d9a2327e236"), true, false, "2230", "عمادة شؤون الطلاب", "Deanship of Student Affairs", true },
                    { 11, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("2a4cf10c-9bff-45d6-b8c1-a9cc39c76abd"), true, false, "3100", "كلية الدراسات التطبيقية وخدمة المجتمع", "College of Applied Studies & Community Services", true },
                    { 12, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("7683cbea-2a4d-4b86-8cdb-c1f98bffbbab"), false, false, "3200", "كلية التربية", "College of Education", true },
                    { 13, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("d58cd45c-e772-4930-ace6-ff8f73562164"), false, false, "3500", "كلية الطب البيطري", "College of Veterinary Medicine", true },
                    { 14, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("8c2571f1-5acf-412e-bc70-15318a302a0e"), false, false, "4311", "عمادة التعلم الإلكتروني وتقنية المعلومات", "Deanship of of E-learning and Information Technology", true },
                    { 15, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("e29da295-9a8b-4976-be0a-22772690fe01"), false, false, "2100", "عمادة التطوير وضمان الجودة", "Deanship of of Development and Quality Assurance", true },
                    { 16, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("0f6645f8-ff4e-4d89-8aff-b14443d2688f"), true, false, "0930", "كلية إدارة الأعمال", "College of Business", true }
                });

            migrationBuilder.InsertData(
                table: "tblSystemRole",
                columns: new[] { "SystemRoleId", "CreationDate", "Guid", "IsActive", "IsDeleted", "RoleTypeAr", "RoleTypeEn", "isSent" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 5, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("fabba72d-d4b0-4c12-be52-a8b868bc6007"), true, false, "مدير النظام", "Admin", true },
                    { 2, new DateTime(2025, 10, 5, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("90d065f4-1a15-40b7-8866-0219b1251646"), true, false, "مشرف النشاط", "Activity Supervisor", true },
                    { 3, new DateTime(2025, 10, 5, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("ea0e8ba3-8b61-44cb-bb9a-e763f1ac6dac"), true, false, "مشرف النادي", "Club Supervisor", true },
                    { 4, new DateTime(2025, 10, 5, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("4ab11078-e7a8-40a3-8a39-a636735b5834"), true, false, "قائد النادي", "Club Leader", true },
                    { 5, new DateTime(2025, 10, 5, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("3e9eda03-140d-4b78-8019-3925ae795e47"), true, false, "الطالب", "Student", true }
                });

            migrationBuilder.InsertData(
                table: "tblStudent",
                columns: new[] { "StudentId", "AcademicId", "CreationDate", "Guid", "IsActive", "IsDeleted", "SiteId", "StudentEmail", "StudentNameAr", "StudentNameEn", "StudentPhone", "StudentSkills", "isSent" },
                values: new object[,]
                {
                    { 1, "221422576", new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("966bf84b-467d-4385-ae94-867f741e75b9"), true, false, 10, "Nebras@gmail.com", "نبراس", "Nebras", "0540345575", "Fast Learner", true },
                    { 2, "220430000", new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("0ad3db67-b821-4503-b0b0-c3c6cf160d36"), true, false, 10, "Safa@gmail.com", "صفا", "Safa", "0509410406", "التعاون", true }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "UserId", "CreationDate", "Guid", "IsActive", "IsDeleted", "SiteId", "SystemROles", "SystemRoleId", "SystemRoleType", "UserEmail", "UserNameAR", "UserNameEN", "UserPhone", "Username", "isSent" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("ca0fad06-8c13-4858-a0a2-4e1115e11ca1"), true, false, null, null, 1, null, "Muntaha@gmail.com", "منتهى", "Muntaha", "0536763284", "Muntaha_12", true },
                    { 2, new DateTime(2025, 10, 13, 11, 43, 22, 0, DateTimeKind.Utc), new Guid("3072cf40-dc60-41f0-87da-77631050caa3"), true, false, null, null, 2, null, "Huda@gmail.com", "هدى", "Huda", "0533924794", "Huda1", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblActivity_ClubId",
                table: "tblActivity",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_tblActivityRequest_ClubID",
                table: "tblActivityRequest",
                column: "ClubID");

            migrationBuilder.CreateIndex(
                name: "IX_tblActivityRequest_SiteID",
                table: "tblActivityRequest",
                column: "SiteID");

            migrationBuilder.CreateIndex(
                name: "IX_tblActivityRequest_UserID",
                table: "tblActivityRequest",
                column: "UserID");

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
                name: "IX_TblMembershipRequest_ClubID",
                table: "TblMembershipRequest",
                column: "ClubID");

            migrationBuilder.CreateIndex(
                name: "IX_TblMembershipRequest_StudentID",
                table: "TblMembershipRequest",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_TblMembershipRequest_TeamID",
                table: "TblMembershipRequest",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_tblPositionRequest_ClubRoleID",
                table: "tblPositionRequest",
                column: "ClubRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_tblPositionRequest_MembershipID",
                table: "tblPositionRequest",
                column: "MembershipID");

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
                name: "IX_tblUser_SiteId",
                table: "tblUser",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_SystemRoleId",
                table: "tblUser",
                column: "SystemRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblActivity");

            migrationBuilder.DropTable(
                name: "tblActivityRequest");

            migrationBuilder.DropTable(
                name: "tblAnnouncement");

            migrationBuilder.DropTable(
                name: "tblEmailNotificationLog");

            migrationBuilder.DropTable(
                name: "tblKFUuser");

            migrationBuilder.DropTable(
                name: "TblMembershipRequest");

            migrationBuilder.DropTable(
                name: "tblPositionRequest");

            migrationBuilder.DropTable(
                name: "tblReport");

            migrationBuilder.DropTable(
                name: "tblSystemLogs");

            migrationBuilder.DropTable(
                name: "tblSystemNotification");

            migrationBuilder.DropTable(
                name: "tblMembership");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "tblClubRole");

            migrationBuilder.DropTable(
                name: "tblStudent");

            migrationBuilder.DropTable(
                name: "tblTeam");

            migrationBuilder.DropTable(
                name: "tblSystemRole");

            migrationBuilder.DropTable(
                name: "tblClub");

            migrationBuilder.DropTable(
                name: "tblSite");
        }
    }
}
