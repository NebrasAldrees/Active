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
            AddStudent();
            AddUser();
            AddSystemRole();

        }




        private static void AddStudent()
        {
            _modelBuilder.Entity<tblStudent>().HasData(
               new tblStudent()
               {
                   StudentId = 1,
                   AcademicId = "221438304",
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
                    CreationDate = new DateTime(2025, 10, 05, 11, 43, 22, DateTimeKind.Utc)
                },
                new tblUser()
                {
                    SystemRoleId = 2,
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
                    CreationDate = new DateTime(2025, 10, 05, 11, 43, 22, DateTimeKind.Utc)
                }
            );
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
                    Guid = Guid.Parse("3322549c-0575-404b-b77e-289785d03460"),
                    CreationDate = new DateTime(2025, 10, 05, 11, 43, 22, DateTimeKind.Utc)
                },
                 new tblSystemRole()
                 {
                     SystemRoleId = 2,
                     RoleTypeAr = "مشرف النشاط",
                     RoleTypeEn = "Activity Supervisor",
                     IsActive = true,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("3322549c-0575-404b-b77e-289785d03460"),
                     CreationDate = new DateTime(2025, 10, 05, 11, 43, 22, DateTimeKind.Utc)
                 },
                 new tblSystemRole()
                 {
                     SystemRoleId = 3,
                     RoleTypeAr = "مشرف النادي",
                     RoleTypeEn = "Club Supervisor",
                     IsActive = true,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("3322549c-0575-404b-b77e-289785d03460"),
                     CreationDate = new DateTime(2025, 10, 05, 11, 43, 22, DateTimeKind.Utc)
                 },
                 new tblSystemRole()
                 {
                     SystemRoleId = 4,
                     RoleTypeAr = "قائد النادي",
                     RoleTypeEn = "Club Leader",
                     IsActive = true,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("3322549c-0575-404b-b77e-289785d03460"),
                     CreationDate = new DateTime(2025, 10, 05, 11, 43, 22, DateTimeKind.Utc)
                 },
                 new tblSystemRole()
                 {
                     SystemRoleId = 5,
                     RoleTypeAr = "الطالب",
                     RoleTypeEn = "Student",
                     IsActive = true,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("3322549c-0575-404b-b77e-289785d03460"),
                     CreationDate = new DateTime(2025, 10, 05, 11, 43, 22, DateTimeKind.Utc)
                 }
                 );
        }

            private static void AddClubRole()
        {
            _modelBuilder.Entity<tblClubRole>().HasData(
                new tblClubRole()
                {
                    ClubRoleId = 1,
                    RoleTypeAr = " قائد النادي",
                    RoleTypeEn = "Club Leader",
                    IsActive = true,
                    isSent = true,
                    IsDeleted = false,
                    Guid = Guid.Parse("abe79246-baad-4783-b3a3-a56e370464b8"),
                    CreationDate = new DateTime(2025, 10, 05, 11, 43, 22, DateTimeKind.Utc)
                },
                 new tblClubRole()
                 {
                     ClubRoleId = 2,
                     RoleTypeAr = " قائد الفريق",
                     RoleTypeEn = "Team Leader",
                     IsActive = true,
                     isSent = true,
                     IsDeleted = false,
                     Guid = Guid.Parse("abe79246-baad-4783-b3a3-a56e370464b8"),
                     CreationDate = new DateTime(2025, 10, 05, 11, 43, 22, DateTimeKind.Utc)
                 },
                  new tblClubRole()
                  {
                      ClubRoleId = 3,
                      RoleTypeAr = " عضو",
                      RoleTypeEn = "Member",
                      IsActive = true,
                      isSent = true,
                      IsDeleted = false,
                      Guid = Guid.Parse("abe79246-baad-4783-b3a3-a56e370464b8"),
                      CreationDate = new DateTime(2025, 10, 05, 11, 43, 22, DateTimeKind.Utc)
                  }
                );
        }

    }
}
