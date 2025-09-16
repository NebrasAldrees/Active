using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.ClubLeader.Controllers
{
    [Area("ClubLeader")]
    public class TeamController : Controller
    {
        private readonly TeamDomain _TeamDomain;
        public TeamController(TeamDomain teamDomain)
        {
            _TeamDomain = teamDomain;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> InsertTeam(TeamViewModel viewModel)
        {
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
    }
}
