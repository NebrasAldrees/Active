using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.Admin.Controllers
{
    [Area("Admin")]
        public class UserController : Controller
        {
            private readonly UserDomain _domain;
            private readonly SystemRoleDomain _systemRoleDomain;
            private readonly SiteDomain _siteDomain;

        public UserController(UserDomain domain, SystemRoleDomain systemRoleDomain, SiteDomain siteDomain)
        {
            _domain = domain;
            _systemRoleDomain = systemRoleDomain;
            _siteDomain = siteDomain;
        }

            public async Task<IActionResult> Index()
            {
                return View(await _domain.GetUser());
            }
        public async Task<IActionResult> InsertUser()
        {
            ViewBag.Site = await _siteDomain.GetSite();
            ViewBag.SystemRole = await _systemRoleDomain.GetSystemRole();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertUser(UserViewModel viewModel)
        {
            ViewBag.Site = await _siteDomain.GetSite();
            ViewBag.SystemRole = await _systemRoleDomain.GetSystemRole();
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _domain.InsertUser(viewModel);
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
            return RedirectToAction("InsertUser");
        }
    }
}

