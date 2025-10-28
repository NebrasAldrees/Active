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
        public async Task<ActionResult> DeleteTeam(Guid Guid)
        {
            int result = await _TeamDomain.DeleteTeam(Guid);

            if (result == 1)
                TempData["Success"] = "تم حذف النادي بنجاح";
            else
                TempData["Error"] = "فشل في الحذف";


            return RedirectToAction("Teams");
        }
    }

}
