using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using System.Security.Claims;

namespace Nashet.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = "Student")]
    public class HomeController : Controller
    {
            private readonly AnnouncementDomain _announcementDomain;

            public HomeController(AnnouncementDomain announcementDomain)
            {
                _announcementDomain = announcementDomain;
            }

        public async Task<IActionResult> StudentHome()
        {
            var latestAnnouncements = await _announcementDomain.GetLatestAnnouncements(3);
            return View(latestAnnouncements);
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
