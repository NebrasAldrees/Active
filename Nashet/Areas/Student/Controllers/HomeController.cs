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
        private readonly StudentDomain _studentDomain;

            public HomeController(AnnouncementDomain announcementDomain, StudentDomain studentDomain)
            {
                _announcementDomain = announcementDomain;
                _studentDomain = studentDomain;
            }

        public async Task<IActionResult> StudentHome()
        {
            var latestAnnouncements = await _announcementDomain.GetLatestAnnouncements(3);
            return View(latestAnnouncements);
        }
        public async Task<IActionResult> ProfilePage()
        {
            var academicNumber = User.FindFirst("AcademicNumber")?.Value ??
                               User.FindFirst(ClaimTypes.Name)?.Value ??
                               User.Identity.Name;

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
                var studentData = await _studentDomain.GetByAcademicId(academicNumber);
                ViewBag.StudentData = studentData;
            }
            else
            {
                ViewBag.StudentData = null;
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSkills(string studentSkills)
        {
            var academicNumber = User.Identity.Name; 

            var result = await _studentDomain.UpdateStudentSkillsAsync(academicNumber, studentSkills);

            if (result)
                return Json(new { success = true, message = "تم التحديث بنجاح" });
            else
                return Json(new { success = false, message = "فشل في التحديث" });
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
