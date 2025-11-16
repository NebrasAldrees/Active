using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.ClubSupervisor.Controllers
{
    [Area("ClubSupervisor")]
    [Authorize(Roles = "ClubSupervisor")]
    public class ActivityRequestController : Controller
    {
        private readonly ActivityRequestDomain _ActivityRequestDomain;
        private readonly ClubDomain _ClubDomain;
        private readonly IWebHostEnvironment _webHost;
        public ActivityRequestController(ActivityRequestDomain activityRequestDomain, ClubDomain clubDomain, IWebHostEnvironment webHost)
        {
            _ActivityRequestDomain = activityRequestDomain;
            _ClubDomain = clubDomain;
            _webHost = webHost;
        }
        public async Task<IActionResult> InsertRequest()
        {
            ViewBag.Club = await _ClubDomain.GetClub();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertRequest(ActivityRequestViewModel viewModel, IFormFile ActivityPoster)
        {
            ViewBag.Club = await _ClubDomain.GetClub();
            if (ModelState.IsValid)
            {
                try
                {
                    if (ActivityPoster != null && ActivityPoster.Length > 0)
                    {
                        string uploadFolder = Path.Combine(_webHost.WebRootPath, "uploads");

                        if (!Directory.Exists(uploadFolder))
                        {
                            Directory.CreateDirectory(uploadFolder);
                        }

                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ActivityPoster.FileName);
                        string fileSavePath = Path.Combine(uploadFolder, fileName);

                        using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                        {
                            await ActivityPoster.CopyToAsync(stream);
                        }

                        viewModel.ActivityPoster = "/uploads/" + fileName;
                        ViewBag.Message = " تم الرفع بنجاح";
                    }

                    int check = await _ActivityRequestDomain.InsertActivityRequest(viewModel);
                    if (check == 1)
                    {
                        ViewBag.Successful = "تم رفع الطلب بنجاح";
                        return View(viewModel);
                    }
                    else
                        ViewBag.Error = "فشل في الإضافة";

                }
                catch (Exception ex)
                {
                    ViewBag.Error = "فشل في الإضافة";
                }
            }


            return View(viewModel);
        }
    }
}
