using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.ActivitiesSupervisor.Controllers
{
    [Area("ActivitiesSupervisor")]
    [Authorize(Roles = "ActivitySupervisor")]

    public class ReportController : Controller
    {
        private readonly ReportDomain _ReportDomain;
        private readonly ClubDomain _ClubDomain;
        public ReportController(ReportDomain reportDomain, ClubDomain clubDomain)
        {
            _ReportDomain = reportDomain;
            _ClubDomain = clubDomain;
        }
        public async Task<IActionResult> ViewAllReports(Guid clubGuid)
        {
            try
            {
                var club = await _ClubDomain.GetClubByGuid(clubGuid);
                if (club == null)
                {
                    TempData["Error"] = "تعذر العثور على النادي";
                    return RedirectToAction("ActivitiesSupervisorHome", "Home", new { area = "ActivitiesSupervisor" });
                }
                var reports = await _ReportDomain.GetReportsByClubId(club.ClubId);


                ViewBag.ClubName = club.ClubNameAR;
                ViewBag.ClubId = club.ClubId;
                ViewBag.ClubGuid = clubGuid;

                return View(reports);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "حدث خطأ أثناء تحميل التقارير";
                return View(new List<ReportViewModel>());
            }
        }
    }
}
