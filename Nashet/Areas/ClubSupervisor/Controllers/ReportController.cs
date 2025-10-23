using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;
using Nashet.Models;
using System.Diagnostics;

namespace Nashet.Areas.ClubSupervisor.Controllers
{
    [Area("ClubSupervisor")]
    public class ReportController : Controller
    {
        private readonly ReportDomain _ReportDomain;
        private readonly ClubDomain _ClubDomain;
        private readonly IWebHostEnvironment _webHost;

        public ReportController(ReportDomain reportDomain,ClubDomain ClubDomain, IWebHostEnvironment webhost)
        {
            _ReportDomain = reportDomain;
            _ClubDomain = ClubDomain;
            _webHost = webhost;
        }
        public async Task<IActionResult> InsertReport()
        {
            ViewBag.Clubs = await _ClubDomain.GetClub();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertReport(ReportViewModel viewModel, IFormFile ReportFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // معالجة رفع ملف التقرير إذا تم رفع ملف
                    if (ReportFile != null && ReportFile.Length > 0)
                    {
                        string uploadFolder = Path.Combine(_webHost.WebRootPath, "Reports");

                        // إنشاء المجلد إذا لم يكن موجوداً
                        if (!Directory.Exists(uploadFolder))
                        {
                            Directory.CreateDirectory(uploadFolder);
                        }

                        // إنشاء اسم فريد للملف مع الاحتفاظ بالامتداد الأصلي
                        string fileExtension = Path.GetExtension(ReportFile.FileName);
                        string fileName = Guid.NewGuid().ToString() + fileExtension;
                        string fileSavePath = Path.Combine(uploadFolder, fileName);

                        // حفظ الملف
                        using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                        {
                            await ReportFile.CopyToAsync(stream);
                        }

                        // حفظ مسار الملف في الـ Path الموجود أصلاً
                        viewModel.Path = "/reports/" + fileName;

                        // يمكنك استخدام Topic لتخزين اسم الملف الأصلي إذا أردت
                        // أو ترك Topic للمستخدم وأضف اسم الملف في نهاية الوصف
                        if (string.IsNullOrEmpty(viewModel.Topic))
                        {
                            viewModel.Topic = Path.GetFileNameWithoutExtension(ReportFile.FileName);
                        }

                        TempData["Message"] = "تم رفع الملف بنجاح: " + ReportFile.FileName;
                    }
                    else
                    {
                        // إذا لم يتم رفع ملف
                        TempData["Failed"] = "الرجاء اختيار ملف للتقرير";
                        return View(viewModel);
                    }

                    int check = await _ReportDomain.InsertReport(viewModel);
                    if (check == 1)
                        TempData["Successful"] = "تم إضافة التقرير بنجاح";
                    else
                        TempData["Failed"] = "فشل إضافة التقرير";
                }
                catch (Exception ex)
                {
                    TempData["Failed"] = "فشل إضافة التقرير: " + ex.Message;
                }
            }
            else
            {
                TempData["Failed"] = "الرجاء ملء جميع الحقول المطلوبة";
            }

            return RedirectToAction("InsertReport");
        }
    }
}
