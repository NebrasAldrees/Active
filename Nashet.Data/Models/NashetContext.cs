using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Models
{
    public class NashetContext : DbContext
    {
        public NashetContext() { }
        public NashetContext(DbContextOptions<NashetContext> options) : base(options) { }

        public DbSet<tblActivity> tblActivity { get; set; }
        public DbSet<tblAnnouncement> tblAnnouncement { get; set; }
        public DbSet<tblClub> tblClub { get; set; }
        public DbSet<tblClubRole> tblClubRole { get; set; }
        public DbSet<tblEmailNotificationLog> tblEmailNotificationLog { get; set; }
        public DbSet<tblKFUuser> tblKFUuser { get; set; }
        public DbSet<tblMembership> tblMembership { get; set; }
        public DbSet<tblReport> tblReport { get; set; }
        public DbSet<tblSite> tblSite { get; set; }
        public DbSet<tblStudent> tblStudent { get; set; }
        public DbSet<tblSystemLogs> tblSystemLogs { get; set; }
        public DbSet<tblSystemNotification> tblSystemNotification { get; set; }
        public DbSet<tblSystemRole> tblSystemRole { get; set; }
        public DbSet<tblUser> tblUser { get; set; }
        public DbSet<tblMembershipRequest> TblMembershipRequest { get; set; }
        public DbSet<tblPositionRequest> tblPositionRequest { get; set; }
        public DbSet<tblActivityRequest> tblActivityRequest { get; set; }
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("NashetContext"));
        }
    }
}
