using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]
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
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _SiteDomain.InsertSite(viewModel);
                    if (check == 1)
                        TempData["Message"] = "تم اضافة الجهة بنجاح";
                    else
                        TempData["Error"] = "فشل في الإضافة";
                }
                catch
                {
                    TempData["Error"] = "فشل في العمليات";
                }
            }
            return RedirectToAction("ViewSites");
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
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _SiteDomain.UpdateSite( viewModel);
                    if (check == 1)
                    {
                        TempData["Message"] = "تم تعديل بيانات الجهة بنجاح";
                        return RedirectToAction(nameof(ViewSites));
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
        public async Task<ActionResult> DeleteSite(Guid guid)
        {
            int result = await _SiteDomain.DeleteSite(guid);

            if (result == 1)
            {
                TempData["Success"] = "تم حذف الجهة بنجاح";
            }
            else
            {
                TempData["Error"] = "خطأ في الحذف";
            }

            return RedirectToAction("ViewSites");
        }



    }
}
