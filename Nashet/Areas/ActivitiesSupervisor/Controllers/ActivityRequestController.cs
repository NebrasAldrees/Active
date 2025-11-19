using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;
using Nashet.Data.Models;
using Nashet.Data.Repository;
using System.Diagnostics;

namespace Nashet.Areas.ActivitiesSupervisor.Controllers
{
    [Area("ActivitiesSupervisor")]
    [Authorize(Roles = "ActivitySupervisor")]

    public class ActivityRequestController : Controller
    {
        private readonly ActivityRequestDomain _ActivityRequestDomain;
        private readonly ActivityDomain _ActivityDomain;
        private readonly ClubDomain _ClubDomain;
        private readonly StatusDomain _StatusDomain;
        public ActivityRequestController(ActivityRequestDomain activityRequestDomain,ActivityDomain activityDomain, ClubDomain clubDomain, StatusDomain statusDomain)
        {
            _ActivityRequestDomain = activityRequestDomain;
            _ActivityDomain = activityDomain;
            _ClubDomain = clubDomain;
            _StatusDomain = statusDomain;
        }
        public async Task<IActionResult> ViewRequests()
        {
            var requests = await _ActivityRequestDomain.GetActivityRequests();
            var clubs = await _ClubDomain.GetClub();
            var statuses = await _StatusDomain.GetStatus();

            var enrichedRequests = requests.Select(r =>
            {
                var club = clubs.FirstOrDefault(c => c.ClubId == r.ClubId);
                var status = statuses.FirstOrDefault(s => s.StatusId == r.StatusId);

                return new ActivityRequestViewModel
                {
                    Guid = r.Guid,
                    ActivityRequestId = r.ActivityRequestId,
                    ActivityTopic = r.ActivityTopic,
                    ActivityDescription = r.ActivityDescription,
                    ActivityStartDate = r.ActivityStartDate,
                    ActivityEndDate = r.ActivityEndDate,
                    ActivityLocation = r.ActivityLocation,
                    ActivityPoster = r.ActivityPoster,
                    StatusId = r.StatusId,
                    StatusTypeAr = status?.StatusTypeAr,
                    ClubId = r.ClubId,
                    ClubNameAR = club?.ClubNameAR,
                    CreationDate = r.CreationDate
                };
            }).ToList();

            return View(enrichedRequests);
        }
        [HttpGet]
        public async Task<IActionResult> RequestDetails(Guid guid)
        {
            var request = await _ActivityRequestDomain.GetRequestByGuid(guid);
            if (request == null)
            {
                return NotFound();
            }

            var club = await _ClubDomain.GetClubById(request.ClubId);
            var status = await _StatusDomain.GetStatusById(request.StatusId); // ✅ Use Guid-based lookup

            var viewModel = new ActivityRequestViewModel
            {
                Guid = request.Guid,
                ActivityRequestId = request.ActivityRequestId,
                ActivityTopic = request.ActivityTopic,
                ActivityDescription = request.ActivityDescription,
                ActivityStartDate = request.ActivityStartDate,
                ActivityEndDate = request.ActivityEndDate,
                ActivityLocation = request.ActivityLocation,
                ActivityPoster = request.ActivityPoster,
                StatusId = request.StatusId,
                StatusTypeAr = status?.StatusTypeAr,
                ClubId = request.ClubId,
                ClubNameAR = club?.ClubNameAR,
                CreationDate = request.CreationDate
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AcceptRequest(Guid guid)
        {
            var request = await _ActivityRequestDomain.GetRequestByGuid(guid);
            if (request == null)
            {
                TempData["Error"] = "تعذر العثور على بيانات الطلب";
                return RedirectToAction("ViewRequests");
            }

            var accepted = await _ActivityRequestDomain.AcceptActivityRequest(guid);
            if (!accepted)
            {
                TempData["Error"] = "فشل في قبول الطلب";
                return RedirectToAction("ViewRequests");
            }
            var club = await _ClubDomain.GetClubById(request.ClubId);
            var viewModel = new ActivityViewModel
            {
                ActivityTopic = request.ActivityTopic,
                ActivityDescription = request.ActivityDescription,
                ActivityStartDate = request.ActivityStartDate,
                ActivityEndDate = request.ActivityEndDate,
                ActivityStartTime = request.ActivityStartDate.ToString("HH:mm"),
                ActivityEndTime = request.ActivityEndDate.ToString("HH:mm"),
                ActivityLocation = request.ActivityLocation,
                ActivityPoster = request.ActivityPoster,
                ClubId = request.ClubId,
                ClubGuid = club.Guid
            };

            var inserted = await _ActivityDomain.InsertActivity(viewModel);
            if (inserted == 1)
            {
                TempData["Success"] = "تم قبول الطلب وإنشاء النشاط بنجاح";
            }
            else
            {
                TempData["Error"] = "تم قبول الطلب ولكن فشل إنشاء النشاط";
            }

            return RedirectToAction("Activities", "Activity", new { area = "ActivitiesSupervisor" });
        }


        [HttpPost]
        public async Task<IActionResult> DeleteRequest(Guid guid)
        {
            var result = await _ActivityRequestDomain.DeleteActivityRequest(guid);

            if (result)
            {
                TempData["Success"] = "تم حذف الطلب بنجاح";
            }
            else
            {
                TempData["Error"] = "فشل في حذف الطلب";
            }

            return RedirectToAction("ViewRequests");
        }

    }
}
