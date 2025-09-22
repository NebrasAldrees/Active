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
        public ReportController(ReportDomain reportDomain)
        {
            _ReportDomain = reportDomain;
        }

        public async Task<IActionResult> InsertReport()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertReport(ReportViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _ReportDomain.InsertReport(viewModel);
                    if (check == 1)
                        ViewData["Successful"] = "Successful";
                    else
                        ViewData["Failed"] = "Failed";
                }
                catch
                {
                    ViewData["Failed"] = "Failed";
                }
            }
            return View(viewModel);
        }
    }
}
