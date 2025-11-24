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

            if (ModelState.IsValid)
            {
                try
                {
                    // معالجة رفع الملف إذا تم رفع ملف
                    if (File != null && File.Length > 0)
                    {
                        string uploadFolder = Path.Combine(_webHost.WebRootPath, "uploads");

                        // إنشاء المجلد إذا لم يكن موجوداً
                        if (!Directory.Exists(uploadFolder))
                        {
                            Directory.CreateDirectory(uploadFolder);
                        }

                        // إنشاء اسم فريد للملف
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(File.FileName);
                        string fileSavePath = Path.Combine(uploadFolder, fileName);

                        // حفظ الملف
                        using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                        {
                            await File.CopyToAsync(stream);
                        }

                        viewModel.Path = "/uploads/" + fileName;
                        ViewBag.Message = fileName + " تم الرفع بنجاح";
                    }

                    int check = await _ReportDomain.InsertReport(viewModel);
                    if (check == 1)
                    {
                        TempData["Successful"] = "تم إضافة التقرير بنجاح";
                        ViewBag.Successful = "تم إضافة التقرير بنجاح";
                        return RedirectToAction("ClubSupervisorHome", "Home");
                    }
                    else if (check == -1)
                    {
                        TempData["Duplicate"] = "عنوان التقرير موجود مسبقاً";
                        ViewBag.Duplicate = "عنوان التقرير موجود مسبقاً";
                    }
                    else
                    {
                        TempData["Failed"] = "فشل إضافة التقرير";
                        ViewBag.Error = "فشل إضافة التقرير";
                    }
                }
                catch (Exception ex)
                {
                    TempData["Failed"] = "فشل إضافة التقرير: " + ex.Message;
                    ViewBag.Error = "فشل إضافة التقرير: " + ex.Message;
                }
            }
            return View(viewModel);
        }
    }
}
