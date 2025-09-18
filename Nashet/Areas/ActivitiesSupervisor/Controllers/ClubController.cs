using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.ActivitiesSupervisor.Controllers
{
    [Area("ActivitiesSupervisor")]
    public class ClubController : Controller
    {
        private readonly ClubDomain _ClubDomain;
        public ClubController(ClubDomain clubDomain)
        {
            _ClubDomain = clubDomain;
        }

        public async Task<IActionResult> Club()
        {
            return View(await _ClubDomain.GetClub());
        }
        public async Task<IActionResult> InsertClub()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertClub(ClubViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _ClubDomain.InsertClub(viewModel);
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
