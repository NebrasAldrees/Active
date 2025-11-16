using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class ClubRoleController : Controller
    {
        
            private readonly ClubRoleDomain _domain;
            public ClubRoleController(ClubRoleDomain domain)
            {
                _domain = domain;
            }

            public async Task<IActionResult> InsertClubRole()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            //public async Task<IActionResult> InsertSystemRole(UserViewModel viewModel)
            public async Task<IActionResult> InsertClubRole(ClubRoleViewModel viewModel)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        int check = await _domain.InsertClubRole(viewModel);
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
                return View("InsertClubRole", viewModel);
            }
        

        public IActionResult Index()
        {
            return View();
        }
    }
}
