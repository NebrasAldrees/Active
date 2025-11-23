using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.ActivitiesSupervisor.Controllers
{
    [Area("ActivitiesSupervisor")]
    [Authorize(Roles = "ActivitySupervisor")]

    public class ClubController : Controller
    {
        private readonly ClubDomain _ClubDomain;
        private readonly SiteDomain _SiteDomain;
        private readonly UserDomain _UserDomain;
        private readonly TeamDomain _TeamDomain;
        private readonly IWebHostEnvironment _webHost;
        public ClubController(ClubDomain clubDomain, SiteDomain siteDomain, UserDomain userDomain,IWebHostEnvironment webhost, TeamDomain teamDomain)
        {
            _ClubDomain = clubDomain;
            _SiteDomain = siteDomain;
            _UserDomain = userDomain;
            _webHost = webhost;
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


            if (!string.IsNullOrEmpty(searchText) && clubs.Any()) //fliting search
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
            try
            {
                var club = await _ClubDomain.GetClubByGuid(guid);
                if (club == null)
                {
                    return NotFound();
                }
                var teams = await _TeamDomain.GetTeamsByClubGuid(guid);
                ViewBag.Teams = teams;

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
            var username = User.Identity?.Name;
            var user = await _UserDomain.GetUserByUsername(username);

            if (user == null || user.SiteId == null)
            {
                TempData["Error"] = "لا يمكنك الوصول إلى هذه الصفحة بدون الانتماء إلى جهة";
                return RedirectToAction("AccessDenied", "Home");
            }

            var site = await _SiteDomain.GetSiteByID(user.SiteId);
            if (site == null)
            {
                TempData["Error"] = "تعذر العثور على بيانات الجهة";
                return RedirectToAction("AccessDenied", "Home");
            }
            ViewBag.SiteName = site.SiteNameAR;
            ViewBag.SiteGuid = site.Guid;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertClub(ClubViewModel viewModel, IFormFile ClubIcon)
        {
            var username = User.Identity?.Name;
            var user = await _UserDomain.GetUserByUsername(username);

            if (user == null || user.SiteId == null)
            {
                TempData["Error"] = "لا يمكنك الوصول إلى هذه الصفحة بدون الانتماء إلى جهة";
                return RedirectToAction("AccessDenied", "Home");
            }

            var site = await _SiteDomain.GetSiteByID(user.SiteId);
            if (site == null)
            {
                TempData["Error"] = "تعذر العثور على بيانات الجهة";
                return RedirectToAction("AccessDenied", "Home");
            }

            ViewBag.SiteName = site.SiteNameAR;
            ViewBag.SiteGuid = site.Guid;


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

                       
                        viewModel.ClubIcon = "/uploads/" + fileName;
                        ViewBag.Message = fileName + " تم الرفع بنجاح";
                    }

                    int check = await _ClubDomain.InsertClub(viewModel);
                    if (check == 1)
                    {
                        TempData["Successful"] = "تم إضافة النادي بنجاح";
                        ViewBag.Successful = "تم إنشاء النادي بنجاح";
                    }
                    else if (check == -1)
                    {
                        TempData["Duplicate"] = "اسم النادي موجود مسبقاً";
                        ViewBag.Duplicate = "اسم النادي موجود مسبقاً";
                    }
                    else
                    {
                        TempData["Failed"] = "فشل إضافة النادي";
                        ViewBag.Error = "فشل إضافة النادي";
                    }
                }
                catch (Exception ex)
                {
                    TempData["Failed"] = "فشل إضافة النادي: " + ex.Message;
                    ViewBag.Error = "فشل إضافة النادي: " + ex.Message;
                }
            }
            return View(viewModel);
        }

        public async Task<IActionResult> UpdateClub(Guid guid)
        {
            try
            {
                var entity = await _ClubDomain.GetClubByGuid(guid);
                if (entity == null)
                {
                    ViewBag.Error = "النادي غير موجود";
                    return RedirectToAction(nameof(ViewAllClubs));
                }
                var username = User.Identity?.Name;
                var user = await _UserDomain.GetUserByUsername(username);

                if (user == null || user.SiteId == null)
                {
                    TempData["Error"] = "لا يمكنك الوصول إلى هذه الصفحة بدون الانتماء إلى جهة";
                    return RedirectToAction("AccessDenied", "Home");
                }

                var site = await _SiteDomain.GetSiteByID(user.SiteId);
                if (site == null)
                {
                    TempData["Error"] = "تعذر العثور على بيانات الجهة";
                    return RedirectToAction("AccessDenied", "Home");
                }
                ViewBag.SiteName = site.SiteNameAR;
                ViewBag.SiteGuid = site.Guid;
                ViewBag.SiteId = site.SiteId;

                var viewModel = new ClubViewModel
                {
                    Guid = entity.Guid,
                    ClubId = entity.ClubId,
                    SiteId = site.SiteId,
                    ClubNameAR = entity.ClubNameAR,
                    ClubNameEN = entity.ClubNameEN,
                    ClubVision = entity.ClubVision,
                    ClubOverview = entity.ClubOverview,
                    ClubIcon = entity.ClubIcon,
                };
                TempData["Successful"] = "تم التحديث بنجاح";
                return View(viewModel);
            }
            catch
            {
                TempData["Error"] = "حدث خطأ أثناء التحديث";
                return RedirectToAction(nameof(ViewAllClubs));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateClub(ClubViewModel viewModel, IFormFile ClubIcon)
        {
            var username = User.Identity?.Name;
            var user = await _UserDomain.GetUserByUsername(username);

            if (user == null || user.SiteId == null)
            {
                TempData["Error"] = "لا يمكنك الوصول إلى هذه الصفحة بدون الانتماء إلى جهة";
                return RedirectToAction("AccessDenied", "Home");
            }

            var site = await _SiteDomain.GetSiteByID(user.SiteId);
            if (site == null)
            {
                TempData["Error"] = "تعذر العثور على بيانات الجهة";
                return RedirectToAction("AccessDenied", "Home");
            }
            ViewBag.SiteName = site.SiteNameAR;
            ViewBag.SiteGuid = site.Guid;
            ViewBag.SiteId = site.SiteId;

            if (ModelState.IsValid)
            {
                try
                {
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


                        viewModel.ClubIcon = "/uploads/" + fileName;
                        ViewBag.Message = fileName + " تم الرفع بنجاح";
                    }
                    int check = await _ClubDomain.UpdateClub(viewModel);
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

        public async Task<ActionResult> DeleteClub(Guid guid)
        {
            try
            {
                var result = await _ClubDomain.DeleteClub(guid);

                if (result)
                {
                    return Json(new
                    {
                        success = true,
                        message = "تم حذف النادي بنجاح"
                    });
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        message = "فشل في حذف النادي"
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
    }
}
