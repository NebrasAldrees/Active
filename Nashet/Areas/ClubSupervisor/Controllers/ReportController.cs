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
            _webHost = webHost;
            _UserDomain = userDomain;
            _ClubDomain = clubDomain;
        }
        //public async Task<IActionResult> InsertReport()
        //{
        //    var username = User.Identity?.Name;
        //    var user = await _UserDomain.GetUserByUsername(username);

        //    // التحقق أن المستخدم مرتبط بنادي
        //    if (user == null || user.ClubId == null)
        //    {
        //        TempData["Error"] = "لا يمكنك الوصول إلى هذه الصفحة بدون الانتماء إلى نادي";
        //        return RedirectToAction("AccessDenied", "Home");
        //    }

        //    // اجلب بيانات النادي
        //    var club = await _ClubDomain.GetClubById(user.ClubId.Value);
        //    if (club == null)
        //    {
        //        TempData["Error"] = "تعذر العثور على بيانات النادي";
        //        return RedirectToAction("AccessDenied", "Home");
        //    }

        //    // تمرير بيانات النادي إلى الـ View
        //    ViewBag.ClubGuid = club.Guid;
        //    ViewBag.ClubName = club.ClubNameAR;

        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> InsertReport(ReportViewModel viewModel) // Remove IFormFile File
        //{
        //    var username = User.Identity?.Name;
        //    var user = await _UserDomain.GetUserByUsername(username);

        //    if (user == null || user.ClubId == null)
        //    {
        //        TempData["Error"] = "لا يمكنك رفع تقرير بدون الانتماء إلى نادي";
        //        return RedirectToAction("AccessDenied", "Home");
        //    }

        //    var club = await _ClubDomain.GetClubById(user.ClubId.Value);
        //    if (club == null)
        //    {
        //        TempData["Error"] = "تعذر العثور على بيانات النادي";
        //        return RedirectToAction("AccessDenied", "Home");
        //    }

        //    viewModel.ClubId = user.ClubId.Value;
        //    viewModel.ClubGuid = club.Guid;

        //    ViewBag.ClubName = club.ClubNameAR;
        //    ViewBag.ClubGuid = club.Guid;

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // معالجة رفع الملف إذا تم رفعه - Use viewModel.File instead of File
        //            if (viewModel.File != null && viewModel.File.Length > 0)
        //            {
        //                string uploadFolder = Path.Combine(_webHost.WebRootPath, "reports");

        //                // إنشاء المجلد إذا لم يكن موجوداً
        //                if (!Directory.Exists(uploadFolder))
        //                {
        //                    Directory.CreateDirectory(uploadFolder);
        //                }

        //                // إنشاء اسم فريد للملف
        //                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(viewModel.File.FileName);
        //                string fileSavePath = Path.Combine(uploadFolder, fileName);

        //                // حفظ الملف
        //                using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
        //                {
        //                    await viewModel.File.CopyToAsync(stream);
        //                }

        //                // تخزين المسار في قاعدة البيانات
        //                viewModel.Path = "/reports/" + fileName;
        //                ViewBag.Message = fileName + " تم رفع التقرير بنجاح";
        //            }

        //            int check = await _ReportDomain.InsertReport(viewModel);
        //            if (check == 1)
        //            {
        //                TempData["Successful"] = "تم رفع التقرير بنجاح";
        //                ViewBag.Successful = "تم رفع التقرير بنجاح";
        //            }
        //            else
        //            {
        //                TempData["Failed"] = "فشل رفع التقرير";
        //                ViewBag.Error = "فشل رفع التقرير";
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            TempData["Failed"] = "فشل رفع التقرير: " + ex.Message;
        //            ViewBag.Error = "فشل رفع التقرير: " + ex.Message;
        //        }
        //    }

        //    return View(viewModel);
        //}
    }
}
