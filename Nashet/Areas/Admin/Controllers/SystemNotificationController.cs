using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SystemNotificationController : Controller
    {

        private readonly SystemNotificationDomain _SystemNotificationDomain;
        public SystemNotificationController(SystemNotificationDomain SystemNotificationDomain)
        {
            _SystemNotificationDomain = SystemNotificationDomain;
        }
        public async Task<IActionResult> ViewNotification()
        {
            return View(await _SystemNotificationDomain.GetAllNotifications());
        }
        public async Task<IActionResult> InsertNotification()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertNotification(SystemNotificationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _SystemNotificationDomain.InsertNotification(viewModel);
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
