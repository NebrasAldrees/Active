using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EmailNotificationController : Controller
    {
        private readonly EmailNotificationDomain _EmailNotificationDomain;

        public EmailNotificationController(EmailNotificationDomain emailNotificationDomain )
        {
            _EmailNotificationDomain = emailNotificationDomain ;
        }
        public async Task <IActionResult> ViewEmail()
        {
            var emails = await _EmailNotificationDomain.GetEmailNotification();

            // لو رجع null، حوله لقائمة فاضية
            return View(emails ?? new List<EmailNotificationViewModel>());
        }
        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> InsertEmail()
        {
            return View();
        }
           [HttpPost]
         [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertEmail(EmailNotificationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _EmailNotificationDomain.InsertEmail(viewModel);
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
