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
        public ReportController(ReportDomain reportDomain)
        {
            _ReportDomain = reportDomain;
        }
        public async Task<IActionResult> ViewAllReports()
        {
            return View(await _ReportDomain.GetReport());
        }
    }
}
