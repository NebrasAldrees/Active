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
            AddUser();
            AddtStudent();
            AddKfuUser();
            AddSite();


        }




        private static void AddtStudent()
        {
            _modelBuilder.Entity<tblStudent>().HasData(
               new tblStudent()
               {
                   StudentId = 5,
                   AcademicId = "221422576",
                   StudentNameAr = "نبراس",
                   StudentNameEn = "Nebras",
                   StudentEmail = "Nebras@gmail.com",
                   IsActive = true,
                   IsDeleted = false,
                   isSent = true,
                   StudentPhone = "0540345575",
                   SiteId = 0920,
                   StudentSkills = "Fast Learner",
                   Guid = Guid.Parse("966bf84b-467d-4385-ae94-867f741e75b9"),
                   CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)

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
                    UserEmail = "Muntaha@gmail.com",
                    IsActive = true,
                    isSent = true,
                    IsDeleted = false,
                    UserPhone = "0536763284",
                    SiteId = null,
                    UserId = 10,
                    Guid = Guid.Parse("ca0fad06-8c13-4858-a0a2-4e1115e11ca1"),
                    CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                },
                new tblUser()
                {
                    SystemRoleId = 2,
                    UserNameEN = "Huda",
                    UserNameAR = "هدى",
                    Username = "Huda1",
                    UserEmail = "Huda@gmail.com",
                    IsActive = true,
                    isSent = true,
                    IsDeleted = false,
                    UserPhone = "0533924794",
                    SiteId = null,
                    UserId = 11,
                    Guid = Guid.Parse("3072cf40-dc60-41f0-87da-77631050caa3"),
                    CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                }
            );
        }
        private static void AddKfuUser()
        {
            _modelBuilder.Entity<tblKFUuser>().HasData(
                new tblKFUuser()
                {
                    KFUUserId = 10,
                    NameEN = "Muntaha",
                    NameAR = "منتهى",
                    Username = "Muntaha_12",
                    Password = "Muntaha",
                    UserEmail = "Muntaha@gmail.com",
                    UserType ="Admin",
                    IsActive = true,
                    isSent = true,
                    IsDeleted = false,
                    UserPhone = "0536763284",
                    Guid = Guid.Parse("7f4a5d58-29db-411b-8e3e-dcf0918e5dc7"),
                    CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                },
                new tblKFUuser()
                {
                    KFUUserId = 11,
                    NameEN = "Huda",
                    NameAR = "هدى",
                    Username = "Huda1",
                    Password = "Huda",
                    UserType = "Activities Supervisor",
                    UserEmail = "Huda@gmail.com",
                    IsActive = true,
                    isSent = true,
                    IsDeleted = false,
                    UserPhone = "0533924794",
                    Guid = Guid.Parse("9ba46550-b007-48cf-9f21-bc473d2b4393"),
                    CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                },
                new tblKFUuser()
                {
                    KFUUserId = 12,
                    NameEN = "Nebras",
                    NameAR = "نبراس",
                    Username = "Nebras2",
                    Password = "Nebras",
                    UserType = "Student",
                    UserEmail = "Nebras@gmail.com",
                    IsActive = true,
                    isSent = true,
                    IsDeleted = false,
                    UserPhone = "0540345575",
                    Guid = Guid.Parse("08d5ea5b-4216-40d6-b166-53c4dfa363e7"),
                    CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                }
            );
        }
        private static void AddSite()
        {
            _modelBuilder.Entity<tblSite>().HasData(
                new tblSite()
                {
                    SiteId = 10,
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
                     SiteId = 11,
                     SiteCode = "",
                     SiteNameAR = "كلية إدارة الأعمال",
                     SiteNameEn = "College of Business",
                     IsActive = true,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("0f6645f8-ff4e-4d89-8aff-b14443d2688f"),
                     CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                 },
                 new tblSite()
                 {
                     SiteId = 12,
                     SiteCode = "",
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
                     SiteId = 13,
                     SiteCode = "",
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
                     SiteId = 14,
                     SiteCode = "",
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
                     SiteId = 15,
                     SiteCode = "",
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
                     SiteId = 16,
                     SiteCode = "",
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
                     SiteId = 17,
                     SiteCode = "",
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
                     SiteId = 18,
                     SiteCode = "",
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
                     SiteId = 19,
                     SiteCode = "",
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
                     SiteId = 20,
                     SiteCode = "",
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
                     SiteId = 21,
                     SiteCode = "",
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
                     SiteId = 22,
                     SiteCode = "",
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
                     SiteId = 23,
                     SiteCode = "",
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
                     SiteId = 24,
                     SiteCode = "",
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
                     SiteId = 25,
                     SiteCode = "",
                     SiteNameAR = "عمادة التطوير وضمان الجودة",
                     SiteNameEn = "Deanship of of Development and Quality Assurance",
                     IsActive = false,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("e29da295-9a8b-4976-be0a-22772690fe01"),
                     CreationDate = new DateTime(2025, 10, 13, 11, 43, 22, DateTimeKind.Utc)
                 }
                 );
        }

    }
}
