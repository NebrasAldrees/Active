using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.ActivitiesSupervisor.Controllers
{
    [Area("ActivitiesSupervisor")]

    public class ActivitiesController : Controller
    {
        private readonly ActivityDomain _ActivityDomain;
        public ActivitiesController(ActivityDomain activityDomain)
        {
            _ActivityDomain = activityDomain;
        }

        public async Task<IActionResult> Activities()
        {
            return View(await _ActivityDomain.GetActivity());
        }
        public async Task<IActionResult> AddActivity()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddActivity(ActivityViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _ActivityDomain.InsertActivity(viewModel);
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
