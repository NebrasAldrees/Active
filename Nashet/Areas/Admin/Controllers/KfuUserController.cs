using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles ="Admin,User")]
    public class KfuUserController : Controller
    {
        private readonly KfuUserDomain _domain;
        private readonly SystemRoleDomain _systemRoleDomain;
        public KfuUserController(KfuUserDomain domain, SystemRoleDomain systemRoleDomain)
        {
            _domain = domain;
            _systemRoleDomain = systemRoleDomain;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _domain.GetGetKfuUser());
        }
        public async Task<IActionResult> InsertKfuUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertKfuUser(KfuUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _domain.InsertKfuUser(viewModel);
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
            return RedirectToAction("InsertKfuUser");
        }
    }
}
