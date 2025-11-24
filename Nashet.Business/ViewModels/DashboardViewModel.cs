using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalSites { get; set; }
        public int TotalKfuUsers { get; set; }
        public int TotalStudents { get; set; }
        public int SitesWithClubs { get; set; }
        public int SitesWithoutClubs { get; set; }
        public int StudentsWithMemberships { get; set; }
        public int StudentsWithoutMemberships { get; set; }
        public int TotalClubs { get; set; }
        public int TotalActivities { get; set; }
        public int TotalMembers { get; set; }

        public List<ClubActivityStat> ClubActivityStats { get; set; }

    }
}
