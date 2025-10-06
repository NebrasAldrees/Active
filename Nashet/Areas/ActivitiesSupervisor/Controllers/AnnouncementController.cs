using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.ActivitiesSupervisor.Controllers
{
    [Area("ActivitiesSupervisor")]
    public class AnnouncementController : Controller
    {
        private readonly AnnouncementDomain _AnnouncementDomain;
        public AnnouncementController(AnnouncementDomain announcementDomain)
        {
            _AnnouncementDomain = announcementDomain;
        }
        public async Task<IActionResult> ViewAnnouncement()
        {
            return View(await _AnnouncementDomain.GetAnnouncement());
        }
        public async Task<IActionResult> InsertAnnouncement()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertAnnouncement(AnnouncementViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _AnnouncementDomain.InsertAnnouncement(viewModel);
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
