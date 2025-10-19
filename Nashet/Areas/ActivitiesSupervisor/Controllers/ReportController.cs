using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.ActivitiesSupervisor.Controllers
{
    [Area("ActivitiesSupervisor")]
    public class ReportController : Controller
    {
        private readonly ReportDomain _ReportDomain;
        private readonly ClubDomain _ClubDomain;
        private readonly IWebHostEnvironment _webHost;
        public ReportController(ReportDomain reportDomain, ClubDomain clubDomain, IWebHostEnvironment webhost)
        {
            _ReportDomain = reportDomain;
            _ClubDomain = clubDomain; 
            _webHost = webhost;

        }
        public async Task<IActionResult> ViewAllReports(Guid reportGuid)
        {
            try
            {
                var report = await _ReportDomain.GetReportByGuid(reportGuid);
                if (report == null)
                {
                    return NotFound();
                }
                return View(report);
            }
            catch
            {
                return NotFound();
            }
        }
        public async Task<IActionResult> ClubReports(Guid clubGuid)
        {
            try
            {
                // تحقق إذا كان GUID صالح
                if (clubGuid == Guid.Empty)
                {
                    TempData["Error"] = "معرف النادي غير صالح";
                    return View(new List<ReportViewModel>());
                }

                // جلب التقارير
                var reports = await _ReportDomain.GetReportsByClubGuid(clubGuid);

                // جلب معلومات النادي
                var club = await _ClubDomain.GetClubByGuid(clubGuid);

                if (club == null)
                {
                    TempData["Error"] = "لم يتم العثور على النادي";
                    return View(new List<ReportViewModel>());
                }

                ViewBag.ClubName = club.ClubNameAR;
                ViewBag.ClubGuid = clubGuid;

                return View(reports);
            }
            catch (Exception ex)
            {
                // لا تعرض رسالة الخطأ الكاملة للمستخدم
                TempData["Error"] = "حدث خطأ أثناء تحميل التقارير";
                // سجل الخطأ للتصحيح فقط
                Console.WriteLine($"Error: {ex.Message}");
                return View(new List<ReportViewModel>());
            }
        }
        public async Task<IActionResult> DownloadReport(Guid reportGuid)
        {
            try
            {
                var report = await _ReportDomain.GetReportByGuid(reportGuid);
                if (report == null || string.IsNullOrEmpty(report.Path))
                {
                    TempData["Error"] = "لم يتم العثور على الملف";
                    return RedirectToAction("ClubReports", new { clubGuid = Request.Query["clubGuid"] });
                }

                // الحصول على المسار الكامل للملف
                var filePath = Path.Combine(_webHost.WebRootPath, report.Path.TrimStart('/'));

                if (!System.IO.File.Exists(filePath))
                {
                    TempData["Error"] = "الملف غير موجود على الخادم";
                    return RedirectToAction("ClubReports", new { clubGuid = Request.Query["clubGuid"] });
                }

                // قراءة الملف
                var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);

                // الحصول على اسم الملف الأصلي أو استخدام العنوان
                var fileName = !string.IsNullOrEmpty(report.Topic) ?
                    report.Topic :
                    $"{report.Topic}{Path.GetExtension(filePath)}";

                // إرجاع الملف للتنزيل
                return File(fileBytes, "application/octet-stream", fileName);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "حدث خطأ أثناء تنزيل الملف";
                return RedirectToAction("ClubReports", new { clubGuid = Request.Query["clubGuid"] });
            }
        }
    }
}
