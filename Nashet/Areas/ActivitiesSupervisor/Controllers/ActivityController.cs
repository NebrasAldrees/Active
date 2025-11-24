using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;
using Nashet.Models;
using System.Diagnostics;

namespace Nashet.Areas.ActivitiesSupervisor.Controllers
{
    [Area("ActivitiesSupervisor")]
    [Authorize(Roles = "ActivitySupervisor")]

    public class ActivityController : Controller
    {
        private readonly ActivityDomain _ActivityDomain;
        private readonly ClubDomain _ClubDomain;
        private readonly IWebHostEnvironment _webHost;
        public ActivityController(ActivityDomain activityDomain,ClubDomain clubDomain, IWebHostEnvironment webHost)
        {
            _ActivityDomain = activityDomain;
            _ClubDomain = clubDomain;
            _webHost = webHost;
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
      
        public async Task<IActionResult> InsertActivity()
        {
            ViewBag.Club = await _ClubDomain.GetClub();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertActivity(ActivityViewModel viewModel, Microsoft.AspNetCore.Http.IFormFile ActivityPoster)
        {
            ViewBag.Club = await _ClubDomain.GetClub();
            if (ModelState.IsValid)
            {
                try
                {
                    if (ActivityPoster != null && ActivityPoster.Length > 0)
                    {
                        string uploadFolder = Path.Combine(_webHost.WebRootPath, "uploads");

                        if (!Directory.Exists(uploadFolder))
                        {
                            Directory.CreateDirectory(uploadFolder);
                        }

                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ActivityPoster.FileName);
                        string fileSavePath = Path.Combine(uploadFolder, fileName);

                        using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                        {
                            await ActivityPoster.CopyToAsync(stream);
                        }

                        viewModel.ActivityPoster = "/uploads/" + fileName;
                        ViewBag.Message = " تم الرفع بنجاح";
                    }

                    int check = await _ActivityDomain.InsertActivity(viewModel);
                    if (check == 1)
                    {
                        ViewBag.Successful = "تم إضافة النشاط بنجاح";
                        return View(viewModel);
                    }

                    else if (check == -1)
                        ViewBag.Duplicate = "اسم النشاط موجود مسبقاً";
                    else
                        ViewBag.Error = "فشل في الإضافة";

                }
                catch (Exception ex)
                {
                    ViewBag.Error = "فشل في الإضافة";
                }
            }


            return View(viewModel);
        }

        public async Task<IActionResult> UpdateActivity(Guid guid)
        {
            try
            {
                var entity = await _ActivityDomain.GetActivityByGuid(guid);
                if (entity == null)
                {
                    ViewBag.Error = "النشاط غير موجود";
                    return RedirectToAction(nameof(Activities));
                }
                ViewBag.Club = await _ClubDomain.GetClub();

                var viewModel = new ActivityViewModel
                {
                    Guid = entity.Guid,
                    ActivityId = entity.ActivityId,
                    ClubId = entity.ClubId,
                    ActivityTopic = entity.ActivityTopic,
                    ActivityDescription = entity.ActivityDescription,
                    ActivityStartDate = entity.ActivityStartDate,
                    ActivityEndDate = entity.ActivityEndDate,
                    ActivityLocation = entity.ActivityLocation,
                    ActivityPoster = entity.ActivityPoster
                };
                TempData["Successful"] = "تم التحديث بنجاح";
                return View(viewModel);
            }
            catch
            {
                TempData["Error"] = "حدث خطأ أثناء التحديث";
                return RedirectToAction(nameof(Activities));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateActivity(ActivityViewModel viewModel, Microsoft.AspNetCore.Http.IFormFile ActivityPoster)
        {
            ViewBag.Club = await _ClubDomain.GetClub();

            if (ModelState.IsValid)
            {
                try
                {
                    if (ActivityPoster != null && ActivityPoster.Length > 0)
                    {
                        string uploadFolder = Path.Combine(_webHost.WebRootPath, "uploads");

                        if (!Directory.Exists(uploadFolder))
                        {
                            Directory.CreateDirectory(uploadFolder);
                        }
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ActivityPoster.FileName);
                        string fileSavePath = Path.Combine(uploadFolder, fileName);

                        using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                        {
                            await ActivityPoster.CopyToAsync(stream);
                        }

                        viewModel.ActivityPoster = "/uploads/" + fileName;
                        ViewBag.Message = fileName + " تم النحديث بنجاح";
                    }
                        int check = await _ActivityDomain.UpdateActivity(viewModel);
                    if (check == 1)
                    {
                        ViewBag.Successful = "تم تحديث البيانات بنجاح";
                        return Json(new { success = true });
                    }
                    else
                        ViewBag.Error = "فشل التحديث";
                }
                catch
                {
                    ViewBag.Error = "فشل التحديث";
                }
            }
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteActivity(Guid guid)
        {
            try
            {
                var result = await _ActivityDomain.DeleteActivity(guid);

                if (result)
                {
                    return Json(new
                    {
                        success = true,
                        message = "تم حذف النشاط بنجاح"
                    });
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        message = "فشل في حذف النشاط"
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = "حدث خطأ: " + ex.Message
                });
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
