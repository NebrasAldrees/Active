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
        private readonly ClubDomain _ClubDomain;
        private readonly UserDomain _UserDomain;

        public ReportController(ReportDomain reportDomain, ClubDomain clubDomain, UserDomain userDomain)
        {
            _ReportDomain = reportDomain;
            _ClubDomain = clubDomain;
            _UserDomain = userDomain;
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
        public async Task<IActionResult> InsertReport(ReportViewModel viewModel)
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
                    int check = await _ReportDomain.InsertReport(viewModel);

                    if (check == 1)
                    {
                        TempData["Successful"] = "تمت الإضافة بنجاح";
                        return RedirectToAction("ViewAllReports", "Report", new
                        {
                            area = "ActivitiesSupervisor",
                            guid = club.Guid
                        });
                    }
                    else
                    {
                        ViewData["Failed"] = "فشل في الإضافة";
                    }
                }
                catch (Exception ex)
                {
                    ViewData["Failed"] = "فشل: " + ex.Message;
                }
            }
            return View(viewModel);
        }
    }
}
