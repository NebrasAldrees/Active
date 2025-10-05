using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                        ViewData["Successful"] = "Site inserted successfully.";
                    else
                        ViewData["Failed"] = "Failed to insert site.";
                }
                catch
                {
                    ViewData["Failed"] = "Failed";
                }
            }
            return View(viewModel);
        }
        public async Task<IActionResult> UpdateSite(SiteViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _SiteDomain.UpdateSite(viewModel);
                    if (check == 1)
                        ViewData["Successful"] = "Site Update successfully.";
                    else
                        ViewData["Failed"] = "Failed to update site.";
                }
                catch
                {
                    ViewData["Failed"] = "Failed";
                }
            }
            return View(viewModel);
        }
        public ActionResult DeleteSite(int id)
        {
            int result = _SiteDomain.DeleteSite(id);

            if (result == 1)
            {
                TempData["Success"] = "Site deleted successfully.";
            }
            else
            {
                TempData["Error"] = "Failed to delete site.";
            }

            return RedirectToAction("ViewSites");
        }


    }
}
