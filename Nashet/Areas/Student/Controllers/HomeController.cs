using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Data.Repository;
using System.Security.Claims;

namespace Nashet.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = "Student")]
    public class HomeController : Controller
    {
        private readonly AnnouncementDomain _announcementDomain;
        private readonly StudentRepository _studentRepository;

            public HomeController(AnnouncementDomain announcementDomain, StudentRepository studentRepository)
            {
                _announcementDomain = announcementDomain;
                _studentRepository = studentRepository;
            }

        public async Task<IActionResult> StudentHome()
        {
            var latestAnnouncements = await _announcementDomain.GetLatestAnnouncements(3);
            return View(latestAnnouncements);
        }
        public async Task<IActionResult> ProfilePage()
        {
            var academicNumber = User.FindFirst("AcademicNumber")?.Value ??
                               User.FindFirst(ClaimTypes.Role)?.Value;

            var userInfo = new
            {
                Username = User.Identity.Name,
                FullName = User.FindFirst(ClaimTypes.GivenName)?.Value,
                Role = User.FindFirst(ClaimTypes.Role)?.Value,
                UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                Email = User.FindFirst(ClaimTypes.Email)?.Value ?? User.Identity.Name,
                AcademicNumber = academicNumber
            };

            ViewBag.UserInfo = userInfo;

            if (!string.IsNullOrEmpty(academicNumber))
            {
                var studentData = await _studentRepository.GetByAcademicIdAsync(academicNumber);
                ViewBag.StudentData = studentData;
            }
            else
            {
                ViewBag.StudentData = null;
            }

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
