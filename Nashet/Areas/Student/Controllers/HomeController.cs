using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Data.Models;
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
        private readonly MembershipDomain _membershipDomain;
        private readonly MembershipRequestDomain _membershiprequestDomain;

            public HomeController(AnnouncementDomain announcementDomain, StudentDomain studentDomain,MembershipDomain membershipDomain, MembershipRequestDomain membershipRequestDomain)
            {
                _announcementDomain = announcementDomain;
                _studentDomain = studentDomain;
            _membershipDomain = membershipDomain;
            _membershiprequestDomain = membershipRequestDomain;
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

                // جلب بيانات العضوية
                var membershipData = await _membershipDomain.GetStudentMembershipAsync(academicNumber);
                ViewBag.MembershipData = membershipData;
            }
            else
            {
                ViewBag.StudentData = null;
                ViewBag.MembershipData = null;
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
        public async Task<IActionResult> ViewAllRequests()
        {
            try
            {
                var academicNumber = User.FindFirst("AcademicNumber")?.Value ??
                                   User.FindFirst(ClaimTypes.Name)?.Value ??
                                   User.Identity.Name;

                if (string.IsNullOrEmpty(academicNumber))
                {
                    TempData["Error"] = "تعذر العثور على الرقم الأكاديمي";
                    return RedirectToAction("ProfilePage");
                }

                var requests = await _membershiprequestDomain.GetStudentRequestsAsync(academicNumber);

                ViewBag.StudentAcademicId = academicNumber;

                return View(requests);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "حدث خطأ أثناء تحميل الطلبات";
                return View(new List<tblMembershipRequest>());
            }
        }
    }
}
