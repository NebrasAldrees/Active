using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

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
        [HttpGet]
        public async Task<IActionResult> ViewUser()
        {
            return View(await _domain.GetUser());
        }
        [HttpGet]
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
                        TempData["Successful"] = "تمت الإضافة بنجاح";  // غير إلى TempData
                    else
                        TempData["Failed"] = "فشلت العملية";  // غير إلى TempData

                    return RedirectToAction("InsertUser");
                }
                catch (Exception ex)
                {
                    TempData["Failed"] = "حدث خطأ: " + ex.Message;  // غير إلى TempData
                }
            }
            else
            {
                TempData["Failed"] = "البيانات غير صالحة";  // غير إلى TempData
            }

           
            return View(viewModel);
        }
    }
}
