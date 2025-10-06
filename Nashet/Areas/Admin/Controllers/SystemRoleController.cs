using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.Admin.Controllers
{

    [Area("Admin")]

    public class SystemRoleController : Controller
    {
        private readonly SystemRoleDomain _domain;
        public SystemRoleController(SystemRoleDomain domain)
        {
            _domain = domain;
        }

        public async Task<IActionResult> InsertSystemRole()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertSystemRole(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _domain.InsertSystemRole(viewModel);
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