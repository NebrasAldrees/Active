using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;
using Nashet.Data.Models;
using Nashet.Data.Repository;

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
            _ActivityRequestDomain = activityRequestDomain;
            _ActivityDomain = activityDomain;
            _ClubDomain = clubDomain;
        }
        public async Task<IActionResult> ViewRequests()
        {
            var Requests = await _ActivityRequestDomain.GetActivityRequests();
            ViewBag.Club = await _ClubDomain.GetClub();
            return View( Requests);
        }
        [HttpGet]
        public async Task<IActionResult> RequestDetails(Guid guid)
        {
            var Requests = await _ActivityRequestDomain.GetRequestByGuid(guid);
            if (Requests == null)
            {
                return NotFound();
            }

            var clubList = await _ClubDomain.GetClub();
            var currentClub = clubList.FirstOrDefault(c => c.ClubId == Requests.ClubId);
            ViewBag.currentClub = currentClub;

            var viewModel = new ActivityRequestViewModel
            {
                Guid = Requests.Guid,
                ActivityRequestId = Requests.ActivityRequestId,
                ActivityTopic = Requests.ActivityTopic,
                ActivityDescription = Requests.ActivityDescription,
                ActivityStartDate = Requests.ActivityStartDate,
                ActivityEndDate = Requests.ActivityEndDate,
                ActivityLocation = Requests.ActivityLocation,
                ActivityPoster = Requests.ActivityPoster,
                StatusId = Requests.StatusId,
                ClubId = Requests.ClubId
            };


            return View(viewModel);
        }
    }
}
