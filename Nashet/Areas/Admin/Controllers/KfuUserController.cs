using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
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
                        TempData["Successful"] = "تمت الإضافة بنجاح";
                    else
                        TempData["Failed"] = "فشل في الإضافة";
                }
                catch
                {
                    TempData["Failed"] = "حدث خطأ أثناء الإضافة";
                }
            }
            else
            {
                TempData["Failed"] = "البيانات المدخلة غير صالحة";
            }
            return RedirectToAction("InsertKfuUser");
        }
    }
}
