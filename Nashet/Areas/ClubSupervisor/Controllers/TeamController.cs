using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;
using Nashet.Models;
using System.Diagnostics;

namespace Nashet.Areas.ClubSupervisor.Controllers
{
    [Area("ClubSupervisor")]
    [Authorize(Roles = "ClubSupervisor")]
    public class TeamController : Controller
    {
        private readonly TeamDomain _TeamDomain;
        private readonly ClubDomain _ClubDomain;
        private readonly UserDomain _UserDomain;

        public TeamController(TeamDomain teamDomain, ClubDomain clubDomain, UserDomain userDomain)
        {
            _TeamDomain = teamDomain;
            _ClubDomain = clubDomain;
            _UserDomain = userDomain;
        }
        public async Task<IActionResult> Teams()
        {
            var username = User.Identity?.Name;
            var user = await _UserDomain.GetUserByUsername(username);

            if (user?.ClubId != null)
            {
                var club = await _ClubDomain.GetClubById(user.ClubId.Value);
                if (club != null)
                {
                    ViewBag.Team = await _TeamDomain.GetTeamsByClubGuid(club.Guid);
                }
            }
            return View(ViewBag.Team);
        }
        public async Task<IActionResult> InsertTeam()
        {
            var username = User.Identity?.Name;
            var user = await _UserDomain.GetUserByUsername(username);

            if (user == null || user.ClubId == null)
            {
                TempData["Error"] = "لا يمكنك الوصول إلى هذه الصفحة بدون الانتماء إلى نادي";
                return RedirectToAction("AccessDenied", "Home");
            }

            var club = await _ClubDomain.GetClubById(user.ClubId.Value);
            if (club == null)
            {
                TempData["Error"] = "تعذر العثور على بيانات النادي";
                return RedirectToAction("AccessDenied", "Home");
            }

            ViewBag.ClubName = club.ClubNameAR;
            ViewBag.ClubGuid = club.Guid;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertTeam(TeamViewModel viewModel)
        {
            var username = User.Identity?.Name;
            var user = await _UserDomain.GetUserByUsername(username);

            if (user == null || user.ClubId == null)
            {
                TempData["Error"] = "لا يمكنك الوصول إلى هذه الصفحة بدون الانتماء إلى نادي";
                return RedirectToAction("AccessDenied", "Home");
            }

            var club = await _ClubDomain.GetClubById(user.ClubId.Value);
            if (club == null)
            {
                TempData["Error"] = "تعذر العثور على بيانات النادي";
                return RedirectToAction("AccessDenied", "Home");
            }

            ViewBag.ClubName = club.ClubNameAR;
            ViewBag.ClubGuid = club.Guid;

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
