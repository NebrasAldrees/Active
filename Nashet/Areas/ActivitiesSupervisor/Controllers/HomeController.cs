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


        public HomeController(ILogger<HomeController> logger, AnnouncementDomain announcementDomain, ClubDomain clubDomain)
        {
            _announcementDomain = announcementDomain;
            _logger = logger;
            _ClubDomain = clubDomain;
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
