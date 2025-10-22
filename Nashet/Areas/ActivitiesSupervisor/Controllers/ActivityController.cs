using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;
using Nashet.Models;
using System.Diagnostics;

namespace Nashet.Areas.ActivitiesSupervisor.Controllers
{
    [Area("ActivitiesSupervisor")]

    public class ActivityController : Controller
    {
        private readonly ActivityDomain _ActivityDomain;
        private readonly ClubDomain _ClubDomain;
        public ActivityController(ActivityDomain activityDomain,ClubDomain clubDomain)
        {
            _ActivityDomain = activityDomain;
            _ClubDomain = clubDomain;
        }

        public async Task<IActionResult> Activities()
        {
            return View(await _ActivityDomain.GetActivity());
        }
        [HttpGet]
        public async Task<IActionResult> ViewActivityById(Guid guid)
        {
            return View(await _ActivityDomain.GetActivityByGuid(guid));
        }

        public async Task<IActionResult> UpdateActivity(Guid Id)
        {
            try
            {
                var entity = await _ActivityDomain.GetActivityByGuid(Id);
                if (entity == null)
                {
                    TempData["Error"] = "النشاط غير موجود";
                    return RedirectToAction(nameof(Activities));
                }

                var viewModel = new ActivityViewModel
                {
                    Guid = entity.Guid,
                    ActivityTopic = entity.ActivityTopic,
                    ActivityDescription = entity.ActivityDescription,
                    ActivityLocation = entity.ActivityLocation,
                    ActivityPoster = entity.ActivityPoster,
                    ActivityStartDate = entity.ActivityStartDate,
                    ActivityEndDate = entity.ActivityEndDate,
                };

                return View(viewModel);
            }
            catch
            {
                return RedirectToAction(nameof(Activities));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateActivity(ActivityViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _ActivityDomain.UpdateActivity(viewModel);
                    if (check == 1)
                    {
                        TempData["Message"] = "تم تعديل بيانات النشاط بنجاح";
                        return RedirectToAction(nameof(Activities));
                    }
                    else
                        TempData["Error"] = "فشل التعديل";
                }
                catch
                {
                    TempData["Error"] = "فشل التعديل";
                }
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> InsertActivity()
        {
            ViewBag.Club = await _ClubDomain.GetClub();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertActivity(ActivityViewModel viewModel)
        {
            ViewBag.Club = await _ClubDomain.GetClub();

            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _ActivityDomain.InsertActivity(viewModel);
                    if (check == 1)
                        ViewData["Successful"] = "تم إضافة النشاط بنجاح";
                    else
                        ViewData["Failed"] = "خطأ في الإضافة";
                }
                catch
                {
                    ViewData["Failed"] = "خطأ في الإضافة";
                }
            }
            return RedirectToAction("InsertActivity");

        }
        public async Task<ActionResult> DeleteActivity(Guid guid)
        {
            int result = await _ActivityDomain.DeleteActivity(guid);

            if (result == 1)
            {
                TempData["Success"] = "تم حذف النشاط بنجاح";
            }
            else
            {
                TempData["Error"] = "خطأ في الحذف";
            }

            return RedirectToAction("Activities");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
