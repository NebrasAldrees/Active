using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = "Student")]
    public class ActivityController : Controller
    {
        private readonly ActivityDomain _ActivityDomain;
        private readonly ClubDomain _ClubDomain;
        public ActivityController(ActivityDomain activityDomain, ClubDomain clubDomain)
        {
            _ActivityDomain = activityDomain;
            _ClubDomain = clubDomain;
        }
        [HttpGet]
        public async Task<IActionResult> Activities(Guid? clubGuid)
        {
            var Activities = await _ActivityDomain.GetActivitiesByClubGuid(clubGuid);
            ViewBag.Club = await _ClubDomain.GetClub();
            return View(Activities);
        }

        [HttpGet]
        public async Task<IActionResult> ActivityPage(Guid guid)
        {
            var activity = await _ActivityDomain.GetActivityByGuid(guid);
            if (activity == null)
            {
                return NotFound();
            }

            var clubList = await _ClubDomain.GetClub();
            var currentClub = clubList.FirstOrDefault(c => c.ClubId == activity.ClubId);
            ViewBag.currentClub = currentClub;

            var viewModel = new ActivityViewModel
            {
                Guid = activity.Guid,
                ActivityId = activity.ActivityId,
                ActivityTopic = activity.ActivityTopic,
                ActivityDescription = activity.ActivityDescription,
                ActivityStartDate = activity.ActivityStartDate,
                ActivityEndDate = activity.ActivityEndDate,
                ActivityLocation = activity.ActivityLocation,
                ActivityPoster = activity.ActivityPoster,
                ClubId = activity.ClubId
            };


            return View(viewModel);
        }
    }
}
