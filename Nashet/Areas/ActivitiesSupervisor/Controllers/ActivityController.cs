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
        private readonly IWebHostEnvironment _webHost;
        public ActivityController(ActivityDomain activityDomain,ClubDomain clubDomain, IWebHostEnvironment webHost)
        {
            _ActivityDomain = activityDomain;
            _ClubDomain = clubDomain;
            _webHost = webHost;
        }

        public async Task<IActionResult> Activities()
        {
            ViewBag.Clubs = await _ClubDomain.GetClub();
            return View(await _ActivityDomain.GetActivity());
        }
        public async Task<IActionResult> ViewActivityByGuid(Guid guid)
        {
            return View(await _ActivityDomain.GetActivityByGuid(guid));
        }
        public async Task<IActionResult> ActivityPage(Guid guid)
        {
            try
            {
                var activity = await _ActivityDomain.GetActivityByGuid(guid);
                if (activity == null)
                {
                    return NotFound();
                }

                var club = await _ClubDomain.GetClub();
                var currentClub = club.FirstOrDefault(c => c.ClubId == activity.ClubId);
                ViewBag.CurrentSite = currentClub;

                return View("ActivityPage", activity);
            }
            catch
            {
                return NotFound();
            }
        }
        public async Task<IActionResult> InsertActivity()
        {
            ViewBag.Club = await _ClubDomain.GetClub();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertActivity(ActivityViewModel viewModel, IFormFile ActivityPoster)
        {
            ViewBag.Club = await _ClubDomain.GetClub();

            if (ModelState.IsValid)
            {
                try
                {

                    // معالجة رفع الصورة إذا تم رفع ملف
                    if (ActivityPoster != null && ActivityPoster.Length > 0)
                    {
                        string uploadFolder = Path.Combine(_webHost.WebRootPath, "uploads");

                        // إنشاء المجلد إذا لم يكن موجوداً
                        if (!Directory.Exists(uploadFolder))
                        {
                            Directory.CreateDirectory(uploadFolder);
                        }

                        // إنشاء اسم فريد للملف
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ActivityPoster.FileName);
                        string fileSavePath = Path.Combine(uploadFolder, fileName);

                        // حفظ الملف
                        using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                        {
                            await ActivityPoster.CopyToAsync(stream);
                        }

                        // حفظ مسار الصورة في الـ ViewModel
                        viewModel.ActivityPoster = "/uploads/" + fileName;
                        ViewBag.Message = fileName + " تم الرفع بنجاح";
                    }

                    int check = await _ActivityDomain.InsertActivity(viewModel);
                    if (check == 1)
                        ViewData["Successful"] = "تم إضافة النشاط بنجاح";
                    else if (check == -1)
                        TempData["Duplicate"] = "اسم النشاط موجود مسبقاً";
                    else
                        ViewData["Failed"] = "فشل في الإضافة";
                }
                catch (Exception ex)
                {
                    ViewData["Failed"] = "فشل في الإضافة";
                }
            }
            return RedirectToAction("Activities");

        }

        public async Task<IActionResult> UpdateActivity(Guid guid)
        {
            try
            {
                var entity = await _ActivityDomain.GetActivityByGuid(guid);
                if (entity == null)
                {
                    TempData["Error"] = "النشاط غير موجود";
                    return RedirectToAction(nameof(Activities));
                }

                var viewModel = new ActivityViewModel
                {
                    Guid = entity.Guid,
                    ActivityId = entity.ActivityId,
                    ActivityTopic = entity.ActivityTopic,
                    ActivityDescription = entity.ActivityDescription,
                    ActivityStartDate = entity.ActivityStartDate,
                    ActivityEndDate = entity.ActivityEndDate,
                    ActivityLocation = entity.ActivityLocation,
                    ActivityPoster = entity.ActivityPoster
                };
                ViewData["Successful"] = "تم تحديث البيانات بنجاح";
                return View(viewModel);
            }
            catch
            {
                TempData["Error"] = "فشل في التحديث";
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
                        TempData["Successful"] = "تم تحديث البيانات بنجاح";
                        return RedirectToAction(nameof(Activities));
                    }
                    else if (check == -1)
                        TempData["Duplicate"] = "اسم النشاط موجود مسبقاً";
                    else
                        TempData["Error"] = "فشل التحديث";
                }
                catch
                {
                    TempData["Error"] = "فشل التحديث";
                }
            }
            return View(viewModel);
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
                TempData["Error"] = "فشل في الحذف";
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
