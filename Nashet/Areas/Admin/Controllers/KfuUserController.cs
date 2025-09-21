using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KfuUserController : Controller
    {
        private readonly KfuUserDomain _domain;
        public KfuUserController(KfuUserDomain domain)
        {
            _domain = domain;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _domain.GetGetKfuUser());
        }
        public async Task<IActionResult> Insert()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(KfuUserViewModel viewModel)
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
            return View(viewModel);
        }
    }
}
