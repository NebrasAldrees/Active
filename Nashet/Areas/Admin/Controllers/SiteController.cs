using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SiteController : Controller
    {
        private readonly SiteDomain _SiteDomain;
        public SiteController(SiteDomain siteDomain)
        {
            _SiteDomain = siteDomain;
        }
        public async Task<IActionResult> ViewSites()
        {
            return View(await _SiteDomain.GetSite());
        }
        [HttpGet]
        public async Task<IActionResult> ViewSiteByGUID(Guid guid)
        {
            return View(await _SiteDomain.GetSiteByGUID(guid));
        }
        
        public async Task<IActionResult> InsertSite()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertSite(SiteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { error = true, message = "البيانات غير صالحة" });
            }

            try
            {
                int check = await _SiteDomain.InsertSite(viewModel);

                if (check == 1)
                {
                    return Json(new { success = true, message = "تم اضافة الجهة بنجاح" });
                }
                else if (check == -1) 
                {
                    return Json(new { duplicate = true, message = "البيانات موجودة مسبقًا" });
                }
                else
                {
                    return Json(new { error = true, message = "فشل في الإضافة" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = true, message = "فشل في العمليات: " + ex.Message });
            }
        }

        public async Task<IActionResult> UpdateSite(Guid guid)
        {
            try
            {
                var entity = await _SiteDomain.GetSiteByGUID(guid);
                if (entity == null)
                {
                    TempData["Error"] = "الجهة غير موجودة";
                    return RedirectToAction(nameof(ViewSites));
                }

                var viewModel = new SiteViewModel
                {
                    Guid = entity.Guid,
                    SiteId = entity.SiteId,
                    SiteCode = entity.SiteCode,
                    SiteNameAR = entity.SiteNameAR,
                    SiteNameEn = entity.SiteNameEn
                };

                return View(viewModel); 
            }
            catch
            {
                return RedirectToAction(nameof(ViewSites));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSite(SiteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "البيانات غير صالحة" });
            }

            try
            {
                int check = await _SiteDomain.UpdateSite(viewModel);

                if (check == 1)
                {
                    return Json(new { success = true, message = "تم تعديل بيانات الجهة بنجاح" });
                }
                else if (check == -1) // optional: duplicate or conflict case
                {
                    return Json(new { success = false, duplicate = true, message = "الجهة موجودة مسبقًا" });
                }
                else
                {
                    return Json(new { success = false, message = "فشل التعديل" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "حدث خطأ أثناء التعديل: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSite(Guid guid)
        {
            try
            {
                int result = await _SiteDomain.DeleteSite(guid);

                if (result == 1)
                {
                    return Json(new { success = true, message = "تم حذف الجهة بنجاح" });
                }
                else
                {
                    return Json(new { success = false, message = "لم يتم العثور على الجهة أو فشل الحذف" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "حدث خطأ أثناء الحذف: " + ex.Message });
            }
        }



    }
}
