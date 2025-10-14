using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.ClubLeader.Controllers
{
    [Area("ClubLeader")]
    public class ClubRoleController : Controller
    {
        private readonly ClubRoleDomain _ClubRoleDomain;
        public ClubRoleController(ClubRoleDomain clubroleDomain)
        {
            _ClubRoleDomain = clubroleDomain;
        }
        public async Task<IActionResult> ViewClubRole()
        {
            return View(await _ClubRoleDomain.GetClubRole());
        }
        public async Task<IActionResult> InsertClubRole()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertClubRole(ClubRoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _ClubRoleDomain.InsertClubRole(viewModel);
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
