using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;
using static System.Reflection.Metadata.BlobBuilder;

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
        private readonly StatusDomain _statusDomain;

        public ActivityRequestController(ActivityRequestDomain activityRequestDomain, ClubDomain clubDomain, UserDomain userDomain,StatusDomain statusDomain,
            IWebHostEnvironment webHost)
        {
            _ActivityRequestDomain = activityRequestDomain;
            _ClubDomain = clubDomain;
            _UserDomain = userDomain;
            _statusDomain = statusDomain;
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

        public async Task<IActionResult> ViewRequests()
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
            var activity = await _ActivityRequestDomain.GetRequestsByClubGuid(club.Guid);
            var statuses = await _statusDomain.GetStatus();
            var enrichedRequests = new List<ActivityRequestViewModel>();
            foreach (var req in activity.Where(r => r.ClubId == user.ClubId))
            {
                var status = statuses.FirstOrDefault(s => s.StatusId == req.StatusId);
                

                enrichedRequests.Add(new ActivityRequestViewModel
                {
                    Guid = req.Guid,
                    ActivityRequestId = req.ActivityRequestId,
                    ActivityTopic = req.ActivityTopic,
                    StatusId = req.StatusId,
                    StatusTypeAr = status?.StatusTypeAr,
                    ClubId = req.ClubId,
                    ClubNameAR = club?.ClubNameAR,
                    CreationDate = req.CreationDate
                });
            }
           
            

            return View(enrichedRequests);

            
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
