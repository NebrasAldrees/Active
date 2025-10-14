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
        private readonly ClubDomain _ClubDomain;
        public ActivityController(ActivityDomain activityDomain,ClubDomain clubDomain)
        {
            _ActivityDomain = activityDomain;
            _ClubDomain = clubDomain;
        }

        public async Task<IActionResult> Activities()
        {
            return View(await _ActivityDomain.GetActivity());
        }
        [HttpGet]
        public async Task<IActionResult> ViewActivityById(int id)
        {
            return View(await _ActivityDomain.GetActivityById(id));
        }

        [HttpGet]
        public async Task<IActionResult> InsertActivity()
        {
            ViewBag.Club = await _ClubDomain.GetClub();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertActivity(ActivityViewModel viewModel)
        {
            ViewBag.Club = await _ClubDomain.GetClub();

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
            return RedirectToAction("InsertActivity");

        }
        public async Task<ActionResult> DeleteActivity(int id)
        {
            int result = await _ActivityDomain.DeleteActivity(id);

            if (result == 1)
            {
                TempData["Success"] = "تم حذف النشاط بنجاح";
            }
            else
            {
                TempData["Error"] = "خطأ في الحذف";
            }

            return RedirectToAction("Activities");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
