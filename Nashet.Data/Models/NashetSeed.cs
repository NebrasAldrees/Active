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
            AddCustomRole();

        }




        private static void AddtStudent()
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
        private static void AddtUser()
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
                    RoleType = "Admin",
                },
                 new tblSystemRole()
                 {
                     SystemRoleId = 2,
                     RoleType = "Activity Supervisor",
                 }
                 );
        }

    }
}
