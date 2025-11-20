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
            private readonly StudentDomain _StudentDomain;

            public HomeController(AnnouncementDomain announcementDomain, StudentDomain studentDomain)
            {
                _announcementDomain = announcementDomain;
                _StudentDomain = studentDomain;
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
            ViewBag.studentId =  _StudentDomain.GetByAcademicId(userInfo.Username);

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
