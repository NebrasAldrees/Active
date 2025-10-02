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
                        ViewData["Successful"] = "Successful";
                    else
                        ViewData["Failed"] = "Failed";
                }
                catch
                {
                    ViewData["Failed"] = "Failed";
                }
            }
            return View(viewModel);
        }
        
    }
}
