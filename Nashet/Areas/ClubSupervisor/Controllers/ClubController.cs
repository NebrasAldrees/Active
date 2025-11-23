using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.ClubSupervisor.Controllers
{
    [Area("ClubSupervisor")]
    [Authorize(Roles = "ClubSupervisor")]
    public class ClubController : Controller
    {
        private readonly ClubDomain _ClubDomain;
        private readonly SiteDomain _SiteDomain;
        private readonly TeamDomain _TeamDomain;

        public ClubController(ClubDomain clubDomain, SiteDomain siteDomain, TeamDomain teamDomain)
        {
            _ClubDomain = clubDomain;
            _SiteDomain = siteDomain;
            _TeamDomain = teamDomain;
        }


        public async Task<IActionResult> ViewAllClubs(Guid? SiteGuid, string? searchText)
        {
            IList<ClubViewModel> clubs = new List<ClubViewModel>();

            if (SiteGuid.HasValue && SiteGuid.Value != Guid.Empty)
            {
                // Filter by siteid
                clubs = await _ClubDomain.GetClubBySiteGuid(SiteGuid);
            }
            else if (!string.IsNullOrEmpty(searchText))
            {
                // Search for club
                clubs = await _ClubDomain.GetClub();
            }


            if (!string.IsNullOrEmpty(searchText) && clubs.Any())
            {
                clubs = clubs.Where(c =>
                    (!string.IsNullOrEmpty(c.ClubNameAR) && c.ClubNameAR.Contains(searchText, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrEmpty(c.ClubNameEN) && c.ClubNameEN.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                ).ToList();
            }


            ViewBag.Site = await _SiteDomain.GetSite();

            return View(clubs);
        }

        public async Task<IActionResult> ClubPage(Guid guid)
        {
            var club = await _ClubDomain.GetClubByGuid(guid);
            if (club == null)
                return NotFound();

            var teams = await _TeamDomain.GetTeamsByClubGuid(guid);
            ViewBag.Teams = teams;

            return View("ClubPage", club);
        }

    }
}
