using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;

namespace Nashet.Areas.Student.Controllers
{
    [Area("Student")]
    public class ClubController : Controller
    {
        private readonly ClubDomain _ClubDomain; 
        private readonly SiteDomain _SiteDomain;

        public ClubController(ClubDomain clubDomain, SiteDomain siteDomain)
        {
            _ClubDomain = clubDomain;
            _SiteDomain = siteDomain;
        }
        public async Task<IActionResult> ViewAllClubs(Guid? SiteGuid)
        {
            var clubs = await _ClubDomain.GetClubBySiteGuid(SiteGuid);
            ViewBag.Site = await _SiteDomain.GetSite();

            return View(clubs);
        }
        public async Task<IActionResult> ClubPage(Guid guid)
        {
            try
            {
                var club = await _ClubDomain.GetClubByGuid(guid);
                if (club == null)
                {
                    return NotFound();
                }

                var sites = await _SiteDomain.GetSite();
                var currentSite = sites.FirstOrDefault(s => s.SiteId == club.SiteId);
                ViewBag.CurrentSite = currentSite;

                return View("ClubPage", club);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
