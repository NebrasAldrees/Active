using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;
using Nashet.Data.Models;
using Nashet.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Nashet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClubDomain _ClubDomain;
        private readonly SiteDomain _SiteDomain;
        private readonly ActivityDomain _ActivityDomain;
        private readonly StudentDomain _StudentDomain;
        private readonly KfuUserDomain _KfuUserDomain;
        private readonly MembershipDomain _MembershipDomain;

        public HomeController(ILogger<HomeController> logger, ClubDomain clubDomain, SiteDomain siteDomain, ActivityDomain activityDomain,
            StudentDomain studentDomain, KfuUserDomain kfuUserDomain, MembershipDomain membershipDomain)
        {
            _logger = logger;
            _ClubDomain = clubDomain;
            _SiteDomain = siteDomain;
            _ActivityDomain = activityDomain;
            _StudentDomain = studentDomain;
            _KfuUserDomain = kfuUserDomain;
            _MembershipDomain = membershipDomain;
        }

        public async Task<IActionResult> AdminHome()
        {
            var sites = await _SiteDomain.GetSite();
            var students = await _StudentDomain.GetStudent();
            var KfuUsers = await _KfuUserDomain.GetGetKfuUser();
            var clubs = await _ClubDomain.GetClub();
            var activities = await _ActivityDomain.GetActivity();
            var memberships = await _MembershipDomain.GetMembership();

            int totalSites = sites.Count;
            int totalStudents = students.Count;
            int totalUsers = KfuUsers.Count;
            int totalMemberships = memberships.Count;
            int sitesWithClubs = sites.Count(s => clubs.Any(c => c.SiteId == s.SiteId));
            int sitesWithoutClubs = totalSites - sitesWithClubs;
            int studentsWithMemberships = students.Count(s => memberships.Any(m => m.StudentId == s.StudentId));
            int studentsWithoutMemberships = totalStudents - studentsWithMemberships;
            int totalClubs = clubs.Count;
            int totalActivities = activities.Count;



            var clubActivityStats = clubs
                .Select(c => new ClubActivityStat
                {
                    ClubName = c.ClubNameAR,
                    ActivityCount = activities.Count(a => a.ClubGuid == c.Guid)
                })
                .OrderByDescending(x => x.ActivityCount)
                .Take(5) // top 5 most active clubs
                .ToList();

            var model = new DashboardViewModel
            {
                TotalSites = totalSites,
                TotalKfuUsers = totalUsers,
                TotalMembers = totalMemberships,
                TotalStudents = totalStudents,
                SitesWithClubs = sitesWithClubs,
                SitesWithoutClubs = sitesWithoutClubs,
                StudentsWithMemberships = studentsWithMemberships,
                StudentsWithoutMemberships = studentsWithoutMemberships,
                TotalClubs = totalClubs,
                TotalActivities = totalActivities,
                ClubActivityStats = clubActivityStats
            };

            return View(model);

        }
        public IActionResult ProfilePage()
        {
            var userInfo = new
            {
                Username = User.Identity.Name,
                FullName = User.FindFirst(ClaimTypes.GivenName)?.Value,
                Role = User.FindFirst(ClaimTypes.Role)?.Value,
                UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                Email = User.FindFirst(ClaimTypes.Email)?.Value ?? User.Identity.Name
            };

            ViewBag.UserInfo = userInfo;
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
