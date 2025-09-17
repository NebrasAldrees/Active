using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.ActivitiesSupervisor.Controllers
{
    [Area("ActivitiesSupervisor")]
    public class ReportController : Controller
    {
        private readonly ReportDomain _ReportDomain;
        public ReportController(ReportDomain reportDomain)
        {
            _ReportDomain = reportDomain;
        }

        public async Task<IActionResult> Report()
        {
            return View(await _ReportDomain.GetReport());
        }
        //public async Task<IActionResult> InsertReport()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> InseertReport(ReportViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            int check = await _ReportDomain.InsertReport(viewModel);
        //            if (check == 1)
        //                ViewData["Successful"] = "Successful";
        //            else
        //                ViewData["Failed"] = "Failed";
        //        }
        //        catch
        //        {
        //            ViewData["Failed"] = "Failed";
        //        }
        //    }
        //    return View(viewModel);
        //}
    }
}
