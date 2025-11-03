using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;
using Nashet.Models;
using System.Diagnostics;

namespace Nashet.Areas.ClubSupervisor.Controllers
{
    [Area("ClubSupervisor")]
    public class TeamController : Controller
    {
        private readonly TeamDomain _TeamDomain;
        private readonly ClubDomain _ClubDomain;
        public TeamController(TeamDomain teamDomain, ClubDomain clubDomain)
        {
            _TeamDomain = teamDomain;
            _ClubDomain = clubDomain;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Teams()
        {
            return View(await _TeamDomain.GetTeam());
        }
        public async Task<IActionResult> InsertTeam()
        {
            ViewBag.Club = await _ClubDomain.GetClub();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertTeam(TeamViewModel viewModel)
        {
            ViewBag.Club = await _ClubDomain.GetClub();

            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _TeamDomain.InsertTeam(viewModel);
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
        [HttpPost]
        public async Task<IActionResult> DeleteTeam(Guid guid)
        {
            var result = await _TeamDomain.DeleteTeam(guid);
            return Json(new { success = true });

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
