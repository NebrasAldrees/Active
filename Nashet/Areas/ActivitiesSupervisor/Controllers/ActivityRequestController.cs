using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;

namespace Nashet.Areas.ActivitiesSupervisor.Controllers
{
    [Area("ActivitiesSupervisor")]
    [Authorize(Roles = "ActivitySupervisor")]

    public class ActivityRequestController : Controller
    {
        private readonly ActivityRequestDomain _ActivityRequestDomain;
        private readonly ActivityDomain _ActivityDomain;
        private readonly ClubDomain _ClubDomain;
        public ActivityRequestController(ActivityRequestDomain activityRequestDomain,ActivityDomain activityDomain, ClubDomain clubDomain)
        {
            _ActivityDomain = activityDomain;
            _ClubDomain = clubDomain;
            _ActivityRequestDomain = activityRequestDomain;
        }
        [HttpGet]
        public async Task<IActionResult> ActivitiyRequests(Guid? clubGuid)
        {
            var Requests = await _ActivityRequestDomain.GetRequestsByClubGuid(clubGuid);
            ViewBag.Club = await _ClubDomain.GetClub();
            return View(Requests);
        }
    }
}
