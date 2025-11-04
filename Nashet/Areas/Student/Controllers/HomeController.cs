using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;

namespace Nashet.Areas.Student.Controllers
{
    [Area("Student")]
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
