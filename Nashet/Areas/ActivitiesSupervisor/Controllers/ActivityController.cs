using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;
using Nashet.Models;
using System.Diagnostics;

namespace Nashet.Areas.ActivitiesSupervisor.Controllers
{
    [Area("ActivitiesSupervisor")]

    public class ActivityController : Controller
    {
        private readonly ActivityDomain _ActivityDomain;
        public ActivityController(ActivityDomain activityDomain)
        {
            _ActivityDomain = activityDomain;
        }

        public async Task<IActionResult> Activities()
        {
            return View(await _ActivityDomain.GetActivity());
        }
        public async Task<IActionResult> InsertActivity()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertActivity(ActivityViewModel viewModel)
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
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
