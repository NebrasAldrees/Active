using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.ActivitiesSupervisor.Controllers
{
    [Area("ActivitiesSupervisor")]
    public class ClubController : Controller
    {
        private readonly ClubDomain _ClubDomain;
        private readonly SiteDomain _SiteDomain;
        private readonly IWebHostEnvironment _webHost;
        public ClubController(ClubDomain clubDomain, SiteDomain siteDomain, IWebHostEnvironment webhost)
        {
            _ClubDomain = clubDomain;
            _SiteDomain = siteDomain;
            _webHost = webhost;
        }
        public async Task<IActionResult> ViewAllClubs()
        {
            ViewBag.Sites = await _SiteDomain.GetSite();
            return View(await _ClubDomain.GetClub());
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
        public async Task<IActionResult> InsertClub()
        {
            ViewBag.Site = await _SiteDomain.GetSite();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertClub(ClubViewModel viewModel, IFormFile ClubIcon)
        {
            ViewBag.Site = await _SiteDomain.GetSite();

            if (ModelState.IsValid)
            {
                try
                {
                    // معالجة رفع الصورة إذا تم رفع ملف
                    if (ClubIcon != null && ClubIcon.Length > 0)
                    {
                        string uploadFolder = Path.Combine(_webHost.WebRootPath, "uploads");

                        // إنشاء المجلد إذا لم يكن موجوداً
                        if (!Directory.Exists(uploadFolder))
                        {
                            Directory.CreateDirectory(uploadFolder);
                        }

                        // إنشاء اسم فريد للملف
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ClubIcon.FileName);
                        string fileSavePath = Path.Combine(uploadFolder, fileName);

                        // حفظ الملف
                        using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                        {
                            await ClubIcon.CopyToAsync(stream);
                        }

                        // حفظ مسار الصورة في الـ ViewModel
                        viewModel.ClubIcon = "/uploads/" + fileName;
                        ViewBag.Message = fileName + " تم الرفع بنجاح";
                    }

                    int check = await _ClubDomain.InsertClub(viewModel);
                    if (check == 1)
                        TempData["Successful"] = "تم إضافة النادي بنجاح";
                    else if (check == -1)
                        TempData["Duplicate"] = "اسم النادي موجود مسبقاً";
                    else
                        TempData["Failed"] = "فشل إضافة النادي";
                }
                catch (Exception ex)
                {
                    TempData["Failed"] = "فشل إضافة النادي: " + ex.Message;
                }
            }
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateClub(Guid guid, ClubViewModel viewModel)
        {
            ViewBag.Site = await _SiteDomain.GetSite();
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _ClubDomain.UpdateClubByGuid(guid, viewModel);
                    if (check == 1)
                        TempData["Successful"] = "تم تعديل البيانات بنجاح";
                    else if (check == -1)
                        TempData["Duplicate"] = "اسم النادي موجود مسبقاً";
                    else
                        TempData["Failed"] = "فشل تعديل البيانات";
                }
                catch
                {
                    TempData["Failed"] = "فشل تعديل البيانات";
                }
            }
            return RedirectToAction("InsertClub");
        }
        public async Task<ActionResult> DeleteClub(Guid guid)
        {
            int result = await _ClubDomain.DeleteClubByGuid(guid);

            if (result == 1)
            {
                TempData["Success"] = "تم حذف النادي بنجاح";
            }
            else
            {
                TempData["Error"] = "فشل حذف النادي";
            }

            return RedirectToAction(nameof(ViewAllClubs));

        }
    }
}
