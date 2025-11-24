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
        private readonly UserDomain _UserDomain;

        public ActivityRequestController(ActivityRequestDomain activityRequestDomain, ClubDomain clubDomain, UserDomain userDomain,
            IWebHostEnvironment webHost)
        {
            _ActivityRequestDomain = activityRequestDomain;
            _ClubDomain = clubDomain;
            _UserDomain = userDomain;
            _webHost = webHost;
        }

        public async Task<IActionResult> InsertRequest()
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
        public async Task<IActionResult> InsertRequest(ActivityRequestViewModel viewModel, Microsoft.AspNetCore.Http.IFormFile ActivityPoster)
        {
            var username = User.Identity?.Name;
            var user = await _UserDomain.GetUserByUsername(username);

            if (user == null || user.ClubId == null)
            {
                TempData["Error"] = "لا يمكنك رفع طلب نشاط بدون الانتماء إلى نادي";
                return RedirectToAction("AccessDenied", "Home");
            }

            var club = await _ClubDomain.GetClubById(user.ClubId.Value);
            if (club == null)
            {
                TempData["Error"] = "تعذر العثور على بيانات النادي";
                return RedirectToAction("AccessDenied", "Home");
            }

            viewModel.ClubId = user.ClubId.Value;
            viewModel.ClubGuid = club.Guid; 

            ViewBag.ClubName = club.ClubNameAR;
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
                    {
                        ViewBag.Error = "فشل في الإضافة";
                    }
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
