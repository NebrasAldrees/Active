using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.ActivitiesSupervisor.Controllers
{
    [Area("ActivitiesSupervisor")]
    public class ClubController : Controller
    {
        private readonly ClubDomain _ClubDomain;
        private readonly SiteDomain _SiteDomain;
        public ClubController(ClubDomain clubDomain,SiteDomain siteDomain)
        {
            _ClubDomain = clubDomain;
            _SiteDomain = siteDomain;
        }
        public async Task<IActionResult> ViewAllClubs()
        {
            ViewBag.Sites = await _SiteDomain.GetSite();
            return View(await _ClubDomain.GetClub());
        }
        public async Task<IActionResult> ClubPage(int id)
        {
            try
            {
                var club = await _ClubDomain.GetClubById(id);
                if (club == null)
                {
                    return NotFound();
                }
                return View("ClubPage", club); // غير "ClubPage" بدل المسار الكامل
            }
            catch
            {
                return NotFound();
            }
        }
        public async Task<IActionResult> InsertClub()
        {
            ViewBag.Site = await _SiteDomain.GetSite();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertClub(ClubViewModel viewModel)
        {
            ViewBag.Site = await _SiteDomain.GetSite();
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _ClubDomain.InsertClub(viewModel);
                    if (check == 1)
                        TempData["Successful"] = "Successful";
                    else if (check == -1)
                        TempData["Duplicate"] = "اسم النادي موجود مسبقاً";
                    else
                        TempData["Failed"] = "Failed";
                }
                catch
                {
                    TempData["Failed"] = "Failed";
                }
            }
            return RedirectToAction("InsertClub");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateClub(int clubid, ClubViewModel viewModel)
        {
            ViewBag.Site = await _SiteDomain.GetSite();
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _ClubDomain.UpdataClub(clubid, viewModel);
                    if (check == 1)
                        TempData["Successful"] = "تم تعديل البيانات بنجاح";
                    else if (check == -1)
                        TempData["Duplicate"] = "اسم النادي موجود مسبقاً";
                    else
                        TempData["Failed"] = "فشل تعديل البيانات";
                }
                catch
                {
                    TempData["Failed"] = "فشل تعديل البيانات";
                }
            }
            return RedirectToAction("InsertClub");
        }
        public async Task<ActionResult> DeleteClub(int id)
        {
            int result = await _ClubDomain.DeleteClub(id);

            if (result == 1)
            {
                TempData["Success"] = "Club deleted successfully";
            }
            else
            {
                TempData["Error"] = "Failed to delete club";
            }

            return RedirectToAction("ViewAllClubs");
        }
    }
}
