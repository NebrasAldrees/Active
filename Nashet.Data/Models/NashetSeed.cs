using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    internal class NashetSeed
    {
        private static ModelBuilder _modelBuilder;

        /// <summary>
        /// This Method Is To Add Default Data To Db
        /// </summary>
        /// <param name="modelBuilder"></param>
        internal static void Seed(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
            AddSystemRole();
            AddSite();
            AddClub();
            AddTeam();
            AddStatus();
            AddtStudent();
            AddUser();
            AddKfuUser();
        }
        private static void AddSystemRole()
        {
            _modelBuilder.Entity<tblSystemRole>().HasData(
                new tblSystemRole()
                {
                    SystemRoleId = 1,
                    RoleTypeAr = "مدير النظام",
                    RoleTypeEn = "Admin",
                    IsActive = true,
                    isSent = true,
                    IsDeleted = false,
                    Guid = Guid.Parse("fabba72d-d4b0-4c12-be52-a8b868bc6007"),
                    CreationDate = new DateTime(2025, 10, 05, 11, 43, 22, DateTimeKind.Utc)
                },
                new tblSystemRole()
                {
                    SystemRoleId = 2,
                    RoleTypeAr = "مشرف النشاط",
                    RoleTypeEn = "ActivitySupervisor",
                    IsActive = true,
                    isSent = true,
                    IsDeleted = false,
                    Guid = Guid.Parse("90d065f4-1a15-40b7-8866-0219b1251646"),
                    CreationDate = new DateTime(2025, 10, 05, 11, 43, 22, DateTimeKind.Utc)
                },
                new tblSystemRole()
                {
                    SystemRoleId = 3,
                    RoleTypeAr = "مشرف النادي",
                    RoleTypeEn = "ClubSupervisor",
                    IsActive = true,
                    isSent = true,
                    IsDeleted = false,
                    Guid = Guid.Parse("ea0e8ba3-8b61-44cb-bb9a-e763f1ac6dac"),
                    CreationDate = new DateTime(2025, 10, 05, 11, 43, 22, DateTimeKind.Utc)
                },
                 new tblSystemRole()
                 {
                     SystemRoleId = 5,
                     RoleTypeAr = "طالب",
                     RoleTypeEn = "Student",
                     IsActive = true,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("3e9eda03-140d-4b78-8019-3925ae795e47"),
                     CreationDate = new DateTime(2025, 10, 05, 11, 43, 22, DateTimeKind.Utc)
                 });
        }
        private static void AddSite()
        {
            _modelBuilder.Entity<tblSite>().HasData(
                new tblSite()
                {
                    SiteId = 1,
                    SiteCode = "0920",
                    SiteNameAR = "كلية علوم الحاسب وتقنية المعلومات",
                    SiteNameEn = "College of Computer Science and Information Technology",
                    IsActive = true,
                    isSent = true,
                    IsDeleted = false,
                    Guid = Guid.Parse("9b7c9604-e3f3-40a4-9015-9916b7cabcff"),
                    CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                },

                 new tblSite()
                 {
                     SiteId = 2,
                     SiteCode = "0940",
                     SiteNameAR = "كلية الهندسة",
                     SiteNameEn = "College of Engineering",
                     IsActive = true,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("8f4336da-ea19-4019-8090-5a6cf70dbf49"),
                     CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                 },
                 new tblSite()
                 {
                     SiteId = 3,
                     SiteCode = "0950",
                     SiteNameAR = "كلية الصيدلة الإكلينيكية",
                     SiteNameEn = "College of Clinical Pharmacy",
                     IsActive = true,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("cc83caab-60ec-4781-a2fc-0cae1217f7fc"),
                     CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                 },
                 new tblSite()
                 {
                     SiteId = 4,
                     SiteCode = "0960",
                     SiteNameAR = "كلية العلوم الطبية",
                     SiteNameEn = "College of Applied Medical Sciences",
                     IsActive = true,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("332f3a58-9aa3-4898-8f29-ff832149c240"),
                     CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                 },
                 new tblSite()
                 {
                     SiteId = 5,
                     SiteCode = "0300",
                     SiteNameAR = "كلية العلوم",
                     SiteNameEn = "College of Science",
                     IsActive = true,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("0fe1af63-f72e-402e-b0b1-87013f4c06b9"),
                     CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                 },
                 new tblSite()
                 {
                     SiteId = 6,
                     SiteCode = "0310",
                     SiteNameAR = "كلية الطب",
                     SiteNameEn = "College of Medicine",
                     IsActive = true,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("4516c8da-9634-4cf6-bfe7-eaa2f1dc5c29"),
                     CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                 },
                 new tblSite()
                 {
                     SiteId = 7,
                     SiteCode = "0320",
                     SiteNameAR = "كلية الحقوق",
                     SiteNameEn = "College of Law",
                     IsActive = true,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("37dba4ea-1caa-4c81-a022-e00e17ec2ebd"),
                     CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                 },
                 new tblSite()
                 {
                     SiteId = 8,
                     SiteCode = "0340",
                     SiteNameAR = "كلية العلوم الزراعية والتغذية",
                     SiteNameEn = "College of Agricultural Science and Nutrition",
                     IsActive = true,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("2110b192-c071-484b-9d03-035ec84f2e9d"),
                     CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                 },
                 new tblSite()
                 {
                     SiteId = 9,
                     SiteCode = "2200",
                     SiteNameAR = "كلية الاداب",
                     SiteNameEn = "College of Arts",
                     IsActive = true,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("4646924f-08b9-4e80-9bab-2318eade4917"),
                     CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                 },
                 new tblSite()
                 {
                     SiteId = 10,
                     SiteCode = "2230",
                     SiteNameAR = "عمادة شؤون الطلاب",
                     SiteNameEn = "Deanship of Student Affairs",
                     IsActive = true,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("fbf9fe3e-45e3-40cf-881c-0d9a2327e236"),
                     CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                 },
                 new tblSite()
                 {
                     SiteId = 11,
                     SiteCode = "3100",
                     SiteNameAR = "كلية الدراسات التطبيقية وخدمة المجتمع",
                     SiteNameEn = "College of Applied Studies & Community Services",
                     IsActive = true,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("2a4cf10c-9bff-45d6-b8c1-a9cc39c76abd"),
                     CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                 },
                 new tblSite()
                 {
                     SiteId = 12,
                     SiteCode = "3200",
                     SiteNameAR = "كلية التربية",
                     SiteNameEn = "College of Education",
                     IsActive = false,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("7683cbea-2a4d-4b86-8cdb-c1f98bffbbab"),
                     CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                 },
                 new tblSite()
                 {
                     SiteId = 13,
                     SiteCode = "3500",
                     SiteNameAR = "كلية الطب البيطري",
                     SiteNameEn = "College of Veterinary Medicine",
                     IsActive = false,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("d58cd45c-e772-4930-ace6-ff8f73562164"),
                     CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                 },
                 new tblSite()
                 {
                     SiteId = 14,
                     SiteCode = "4311",
                     SiteNameAR = "عمادة التعلم الإلكتروني وتقنية المعلومات",
                     SiteNameEn = "Deanship of of E-learning and Information Technology",
                     IsActive = false,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("8c2571f1-5acf-412e-bc70-15318a302a0e"),
                     CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                 },
                 new tblSite()
                 {
                     SiteId = 15,
                     SiteCode = "2100",
                     SiteNameAR = "عمادة التطوير وضمان الجودة",
                     SiteNameEn = "Deanship of of Development and Quality Assurance",
                     IsActive = false,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("e29da295-9a8b-4976-be0a-22772690fe01"),
                     CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                 },
                 new tblSite()
                 {
                     SiteId = 16,
                     SiteCode = "0930",
                     SiteNameAR = "كلية إدارة الأعمال",
                     SiteNameEn = "College of Business",
                     IsActive = true,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("0f6645f8-ff4e-4d89-8aff-b14443d2688f"),
                     CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                 }
                 );
        }

        private static void AddClub()
        {
            _modelBuilder.Entity<tblClub>().HasData(
                new tblClub()
                {
                    Guid = Guid.Parse("22370d9b-c4fe-4464-bf11-011db9fb7889"),
                    ClubId = 1,
                    siteId = 1,
                    ClubNameAR = "نادي الذكاء الاصطناعي",
                    ClubNameEN = "Artificial Intelligence (AI)",
                    ClubVision = "يهدف النادي إلى تطوير البيئات التثنية باستخدام الذكاء الاصطناعي",
                    ClubOverview = "نادي تعليمي وهادف",
                    IsActive = true,
                    isSent = true,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                },

            new tblClub()
            {
                Guid = Guid.Parse("a28dd9d4-0916-46b2-8fae-aae015bbb78c"),
                ClubId = 2,
                siteId = 1,
                ClubNameAR = "نادي التعلم بالأقران",
                ClubNameEN = "PTI",
                ClubVision = "يهدف النادي إلى تطوير التعلم الجماعي ومساعدة الأفراد",
                ClubOverview = "نادي تعليمي وهادف",
                IsActive = true,
                isSent = true,
                IsDeleted = false,
                CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
            },

            new tblClub()
            {
                Guid = Guid.Parse("5ea71484-15dc-4dc8-a175-dcb93a487a57"),
                ClubId = 3,
                siteId = 1,
                ClubNameAR = "نادي تطوير الويب",
                ClubNameEN = "Web Application",
                ClubVision = "يهدف النادي إلى تطوير مواقع الويب",
                ClubOverview = "نادي تعليمي وهادف",
                IsActive = true,
                isSent = true,
                IsDeleted = false,
                CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
            });
        }
        private static void AddTeam()
        {
            _modelBuilder.Entity<tblTeam>().HasData(
                new tblTeam()
                {
                    Guid = Guid.Parse("ec23cc85-fd2f-439f-a71d-a1d8e20f8f34"),
                    ClubId = 1,
                    TeamId = 1,
                    TeamNameAR = "فريق البرمجة",
                    TeamNameEn = "Programming Team",
                    IsActive = true,
                    isSent = true,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                },


            new tblTeam()
            {
                Guid = Guid.Parse("e7f0778c-f4f4-4aa7-b7c0-d4e4ccbeb4c6"),
                ClubId = 1,
                TeamId = 2,
                TeamNameAR = "فريق الإعلام",
                TeamNameEn = "Media Team",
                IsActive = true,
                isSent = true,
                IsDeleted = false,
                CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
            },
            new tblTeam()
            {
                Guid = Guid.Parse("732181fb-62be-448b-8be4-651bfa2634d1"),
                ClubId = 2,
                TeamId = 3,
                TeamNameAR = "فريق تطوير الويب ",
                TeamNameEn = "Web development Team",
                IsActive = true,
                isSent = true,
                IsDeleted = false,
                CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
            },
            new tblTeam()
            {
                Guid = Guid.Parse("fee080a7-95d8-47bf-9c8e-477066d9f983"),
                ClubId = 2,
                TeamId = 4,
                TeamNameAR = "الفريق الإعلامي لتطوير الويب ",
                TeamNameEn = "Media Web developement Team",
                IsActive = true,
                isSent = true,
                IsDeleted = false,
                CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
            },
            new tblTeam()
            {
                Guid = Guid.Parse("e69833df-ccb1-4e07-89fe-d6267994e186"),
                ClubId = 2,
                TeamId = 5,
                TeamNameAR = "فريق الابتكار",
                TeamNameEn = "Innovation Team",
                IsActive = true,
                isSent = true,
                IsDeleted = false,
                CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
            },
            new tblTeam()
            {
                Guid = Guid.Parse("1a3b1005-1258-4c9a-b375-e716f6583f5c"),
                ClubId = 1,
                TeamId = 6,
                TeamNameAR = "فريق التطوير للذكاء",
                TeamNameEn = "Developement Team",
                IsActive = true,
                isSent = true,
                IsDeleted = false,
                CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
            });


        }
        private static void AddStatus()
        {
            _modelBuilder.Entity<tblStatus>().HasData(
               new tblStatus()
               {
                   StatusId = 1,
                   StatusTypeAr = "قيد الانتظار",
                   StatusTypeEn = "Pending",
                   IsActive = true,
                   IsDeleted = false,
                   isSent = true,
                   Guid = Guid.Parse("420b839c-af93-46ed-962b-8d6154e48c9c"),
                   CreationDate = new DateTime(2025, 11, 17, 11, 43, 22, DateTimeKind.Utc)

               },
               new tblStatus()
               {
                   StatusId = 2,
                   StatusTypeAr = "تمت الموافقة",
                   StatusTypeEn = "Approved",
                   IsActive = true,
                   IsDeleted = false,
                   isSent = true,
                   Guid = Guid.Parse("3c63e5da-1f30-4ffb-a660-28692aaa0a06"),
                   CreationDate = new DateTime(2025, 11, 17, 11, 43, 22, DateTimeKind.Utc)

               },
               new tblStatus()
               {
                   StatusId = 3,
                   StatusTypeAr = "مرفوض",
                   StatusTypeEn = "Rejected",
                   IsActive = true,
                   IsDeleted = false,
                   isSent = true,
                   Guid = Guid.Parse("fa97ca20-b67d-463d-b38e-b8a3732fbc9c"),
                   CreationDate = new DateTime(2025, 11, 17, 11, 43, 22, DateTimeKind.Utc)

               });
        }
        private static void AddtStudent()
        {
            _modelBuilder.Entity<tblStudent>().HasData(
               new tblStudent()
               {
                   StudentId = 1,
                   AcademicId = "221422576",
                   StudentNameAr = "نبراس",
                   StudentNameEn = "Nebras",
                   StudentEmail = "221422576@student.kfu.edu.sa",
                   IsActive = true,
                   IsDeleted = false,
                   isSent = true,
                   StudentPhone = "0540345575",
                   SiteId = 10,
                   StudentSkills = "Flexibility, Fast Learner",
                   Guid = Guid.Parse("8cc028e3-bcac-484e-b6a4-36941a618eaa"),
                   CreationDate = new DateTime(2025, 11, 20, 21, 43, 22, DateTimeKind.Utc)

               });
        }
        private static void AddUser()
        {
            _modelBuilder.Entity<tblUser>().HasData(
                new tblUser()
                {
                    SystemRoleId = 1,
                    UserNameEN = "Muntaha",
                    UserNameAR = "منتهى",
                    Username = "Muntaha_12",
                    UserEmail = "Muntaha_12@gmail.com",
                    IsActive = true,
                    isSent = true,
                    IsDeleted = false,
                    UserPhone = "0536763284",
                    SiteId = 1,
                    UserId = 1,
                    Guid = Guid.Parse("34b1ede7-f035-41b0-9a4d-bca1808d1b15"),
                    CreationDate = new DateTime(2025, 11, 20, 11, 43, 22, DateTimeKind.Utc)
                },
                new tblUser()
                {
                    SystemRoleId = 2,
                    UserNameEN = "Huda",
                    UserNameAR = "هدى",
                    Username = "Huda1",
                    UserEmail = "Huda1@gmail.com",
                    IsActive = true,
                    isSent = true,
                    IsDeleted = false,
                    UserPhone = "0533924794",
                    SiteId = 1,
                    UserId = 2,
                    Guid = Guid.Parse("bcbe728f-6ae0-4edf-ac9d-1ecb7fb70430"),
                    CreationDate = new DateTime(2025, 11, 20, 11, 43, 22, DateTimeKind.Utc)
                },
                new tblUser()
                {
                    SystemRoleId = 3,
                    UserNameEN = "Safaa",
                    UserNameAR = "صفا",
                    Username = "Safaa2",
                    UserEmail = "Safaa2@gmail.com",
                    IsActive = true,
                    isSent = true,
                    IsDeleted = false,
                    UserPhone = "0509410406",
                    SiteId = 1,
                    ClubId = 1,
                    UserId = 3,
                    Guid = Guid.Parse("d71c8b67-a3c5-439b-988a-90036bd296c2"),
                    CreationDate = new DateTime(2025, 11, 20, 11, 43, 22, DateTimeKind.Utc)
                }
            );
        }
        private static void AddKfuUser()
        {
            _modelBuilder.Entity<tblKFUuser>().HasData(
                new tblKFUuser()
                {
                    KFUUserId = 1,
                    NameEN = "Muntaha",
                    NameAR = "منتهى",
                    Username = "Muntaha_12",
                    Password = "Muntaha",
                    UserEmail = "Muntaha_12@gmail.com",
                    UserType = "Staff",
                    IsActive = true,
                    isSent = true,
                    IsDeleted = false,
                    UserPhone = "0536763284",
                    Guid = Guid.Parse("7f4a5d58-29db-411b-8e3e-dcf0918e5dc7"),
                    CreationDate = new DateTime(2025, 11, 20, 11, 43, 22, DateTimeKind.Utc)
                },
                new tblKFUuser()
                {
                    KFUUserId = 2,
                    NameEN = "Huda",
                    NameAR = "هدى",
                    Username = "Huda1",
                    Password = "Huda",
                    UserType = "Staff",
                    UserEmail = "Huda1@gmail.com",
                    IsActive = true,
                    isSent = true,
                    IsDeleted = false,
                    UserPhone = "0533924794",
                    Guid = Guid.Parse("ae75dc8b-2ab9-4ff1-a623-f79e56425e14"),
                    CreationDate = new DateTime(2025, 11, 20, 11, 43, 22, DateTimeKind.Utc)
                },
                new tblKFUuser()
                {
                    KFUUserId = 3,
                    NameEN = "Nebras Aldrees",
                    NameAR = " نبراس الدريس",
                    Username = "221422576",
                    Password = "Nebras",
                    UserType = "Student",
                    UserEmail = "221422576@student.kfu.edu.sa",
                    IsActive = true,
                    isSent = true,
                    IsDeleted = false,
                    UserPhone = "0540345575",
                    Guid = Guid.Parse("687b0a3a-06de-499c-a575-f7719b954793"),
                    CreationDate = new DateTime(2025, 11, 20, 11, 43, 22, DateTimeKind.Utc)
                },
                new tblKFUuser()
                {
                    KFUUserId = 4,
                    NameEN = "Safaa",
                    NameAR = "صفا",
                    Username = "Safaa2",
                    Password = "Safaa",
                    UserType = "Staff",
                    UserEmail = "Safaa2@gmail.com",
                    IsActive = true,
                    isSent = true,
                    IsDeleted = false,
                    UserPhone = "0509410406",
                    Guid = Guid.Parse("5af5cde5-542c-49c1-a8ab-6c439fcf5d54"),
                    CreationDate = new DateTime(2025, 11, 20, 11, 43, 22, DateTimeKind.Utc)
                }
            );
        }


    }
}