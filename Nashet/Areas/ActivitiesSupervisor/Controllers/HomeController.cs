using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Data.Models;
using Nashet.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Nashet.Areas.ActivitiesSupervisor.Controllers
{
    [Area("ActivitiesSupervisor")]
    [Authorize(Roles = "ActivitySupervisor")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AnnouncementDomain _announcementDomain;
        private readonly ClubDomain _ClubDomain;
        private readonly UserDomain _UserDomain;
        private readonly SiteDomain _SiteDomain;


        public HomeController(ILogger<HomeController> logger, AnnouncementDomain announcementDomain, ClubDomain clubDomain, UserDomain userDomain, SiteDomain siteDomain)
        {
            _announcementDomain = announcementDomain;
            _logger = logger;
            _ClubDomain = clubDomain;
            _UserDomain = userDomain;
            _SiteDomain = siteDomain;
        }
        [HttpGet]
        public async Task<IActionResult> ProfilePage()
        {
            try
            {
                var username = User.Identity?.Name;
                var user = await _UserDomain.GetUserByUsername(username);

                if (user == null)
                {
                    return NotFound();
                }

                string siteName = "غير محدد";
                if (user.SiteId != null)
                {
                    var site = await _SiteDomain.GetSiteByID(user.SiteId);
                    if (site != null)
                    {
                        siteName = site.SiteNameAR;
                    }
                }

                ViewBag.SiteName = siteName;
                ViewBag.SiteId = user.SiteId;

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.SiteName = "غير محدد";
                ViewBag.SiteId = "غير متوفر";
                return View();
            }
        }
        public async Task<IActionResult> ActivitiesSupervisorHome()
        {
            var latestAnnouncements = await _announcementDomain.GetLatestAnnouncements(3);
            return View(latestAnnouncements);
        }
        [HttpGet]
        public async Task<IActionResult> AnnouncementPage(Guid id)
        {
            try
            {
                var announcement = await _announcementDomain.GetAnnouncementByGuid(id);
                return View(announcement);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
