using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using System.Security.Claims;

namespace Nashet.Areas.ClubSupervisor.Controllers
{
    [Area("ClubSupervisor")]
    [Authorize(Roles = "ClubSupervisor")]
    public class HomeController : Controller
    {
        private readonly AnnouncementDomain _announcementDomain;
        private readonly UserDomain _UserDomain;
        private readonly SiteDomain _SiteDomain;
        private readonly ClubDomain _ClubDomain;

        public HomeController(AnnouncementDomain announcementDomain, UserDomain userDomain, SiteDomain siteDomain, ClubDomain clubDomain)
        {
            _announcementDomain = announcementDomain;
            _UserDomain = userDomain;
            _SiteDomain = siteDomain;
            _ClubDomain = clubDomain;
        }

        public async Task<IActionResult> ClubsupervisorHome()
        {
            var latestAnnouncements = await _announcementDomain.GetLatestAnnouncements(3);
            return View(latestAnnouncements);
        }
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

                string clubName = "غير محدد";
                string siteName = "غير محدد";

                // جلب بيانات النادي
                if (user.ClubId != null && user.ClubId != 0)
                {
                    var club = await _ClubDomain.GetClubById((int)user.ClubId);
                    if (club != null)
                    {
                        clubName = club.ClubNameAR;

                        // جلب بيانات الجهة من خلال النادي
                        if (club.SiteId != null && club.SiteId != 0)
                        {
                            var site = await _SiteDomain.GetSiteByID(club.SiteId);
                            if (site != null)
                            {
                                siteName = site.SiteNameAR;
                            }
                        }
                    }
                }

                ViewBag.ClubName = clubName;
                ViewBag.SiteName = siteName;
                ViewBag.ClubId = user.ClubId;

                return View();
            }
            catch (Exception ex)
            {
                // في حالة الخطأ، استخدم قيم افتراضية
                ViewBag.ClubName = "غير محدد";
                ViewBag.SiteName = "غير محدد";
                ViewBag.ClubId = "غير متوفر";
                return View();
            }
        }
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
    }
}
