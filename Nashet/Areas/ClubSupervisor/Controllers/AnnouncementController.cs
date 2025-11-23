using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.ClubSupervisor.Controllers
{
    [Area("ClubSupervisor")]
    [Authorize(Roles = "ClubSupervisor")]
    public class AnnouncementController : Controller
    {
        private readonly AnnouncementDomain _AnnouncementDomain;
        private readonly ClubDomain _ClubDomain;
        public AnnouncementController(AnnouncementDomain announcementDomain, ClubDomain clubDomain)
        {
            _AnnouncementDomain = announcementDomain;
            _ClubDomain = clubDomain;
        }

        public async Task<IActionResult> GetAnnouncement()
        {
            return View(await _AnnouncementDomain.GetAnnouncement());
        }
        
        
        [HttpGet]
        public async Task<IActionResult> AnnouncementPage(Guid id)
        {
            try
            {
                var announcement = await _AnnouncementDomain.GetAnnouncementByGuid(id);
                if (announcement == null)
                {
                    return NotFound();
                }

                var clubList = await _ClubDomain.GetClub();
                var currentClub = clubList.FirstOrDefault(c => c.ClubId == announcement.ClubId);
                ViewBag.currentClub = currentClub;

                return View(announcement);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
