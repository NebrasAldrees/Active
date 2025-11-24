using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;
using Nashet.Models;
using System.Diagnostics;

namespace Nashet.Areas.ClubSupervisor.Controllers
{
    [Area("ClubSupervisor")]
    [Authorize(Roles = "ClubSupervisor")]
    public class ReportController : Controller
    {
        private readonly ReportDomain _ReportDomain;
        private readonly UserDomain _UserDomain;
        private readonly ClubDomain _ClubDomain;
        private readonly IWebHostEnvironment _webHost;
        public ReportController(ReportDomain reportDomain, IWebHostEnvironment webHost, UserDomain userDomain, ClubDomain clubDomain)
        {
            _ReportDomain = reportDomain;
            _UserDomain = userDomain;
            _ClubDomain = clubDomain;
            _webHost = webHost;
        }
        public async Task<IActionResult> InsertReport()
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
        public async Task<IActionResult> InsertReport(ReportViewModel viewModel, Microsoft.AspNetCore.Http.IFormFile File)
        {
            var username = User.Identity?.Name;
            var user = await _UserDomain.GetUserByUsername(username);

            if (user == null || user.ClubId == null)
            {
                ViewBag.Error = "لا يمكنك الوصول إلى هذه الصفحة بدون الانتماء إلى نادي";
                return View(viewModel);
            }

            var club = await _ClubDomain.GetClubById(user.ClubId.Value);
            if (club == null)
            {
                ViewBag.Error = "تعذر العثور على بيانات النادي";
                return View(viewModel);
            }

            ViewBag.ClubName = club.ClubNameAR;
            ViewBag.ClubGuid = club.Guid;

            if (ModelState.IsValid)
            {
                try
                {
                    if (File != null && File.Length > 0)
                    {
                        string uploadFolder = Path.Combine(_webHost.WebRootPath, "uploads");

                        if (!Directory.Exists(uploadFolder))
                        {
                            Directory.CreateDirectory(uploadFolder);
                        }

                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(File.FileName);
                        string fileSavePath = Path.Combine(uploadFolder, fileName);

                        using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                        {
                            await File.CopyToAsync(stream);
                        }

                        viewModel.Path = "/uploads/" + fileName;
                    }

                    int check = await _ReportDomain.InsertReport(viewModel);
                    if (check == 1)
                    {
                        ViewBag.Successful = "تم إضافة التقرير بنجاح";
                        ModelState.Clear();
                        var newViewModel = new ReportViewModel();
                        return View(newViewModel);
                    }
                    else if (check == -1)
                    {
                        ViewBag.Duplicate = "عنوان التقرير موجود مسبقاً";
                    }
                    else
                    {
                        ViewBag.Error = "فشل إضافة التقرير";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "فشل إضافة التقرير: " + ex.Message;
                }
            }
            return View(viewModel);
        }
    }
}
