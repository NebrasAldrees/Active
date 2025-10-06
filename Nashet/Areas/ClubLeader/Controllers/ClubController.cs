using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;

namespace Nashet.Areas.ClubLeader.Controllers
{
    [Area("ClubLeader")]
    public class ClubController : Controller
    {
        private readonly ClubDomain _ClubDomain;
        public ClubController(ClubDomain clubDomain)
        {
            _ClubDomain = clubDomain;
        }
        public async Task<IActionResult> ViewAllClubs()
        {
            return View(await _ClubDomain.GetClub());
        }
    }
}
