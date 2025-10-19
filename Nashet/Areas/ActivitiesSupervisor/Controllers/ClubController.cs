using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.ActivitiesSupervisor.Controllers
{
    [Area("ActivitiesSupervisor")]
    public class ClubController : Controller
    {
        private readonly ClubDomain _ClubDomain;
        public ClubController(ClubDomain clubDomain)
        {
            _ClubDomain = clubDomain;
        }
        public async Task<IActionResult> ViewAllClubs()
        {
            return View(await _ClubDomain.GetClub());
        }
        public async Task<IActionResult> ClubPage(int id)
        {
            try
            {
                var club = await _ClubDomain.GetClubById(id);
                return View(club);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
        public async Task<IActionResult> InsertClub()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertClub(ClubViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _ClubDomain.InsertClub(viewModel);
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
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteClub(int id)
        //{
        //    try
        //    {
        //        int result = await _ClubDomain.DeleteClub(id);
        //        if (result == 1)
        //        {
        //            TempData["Message"] = "تم حذف النادي بنجاح";
        //        }
        //        else
        //        {
        //            TempData["Error"] = "فشل في حذف النادي";
        //        }
        //    }
        //    catch
        //    {
        //        TempData["Error"] = "حدث خطأ أثناء حذف النادي";
        //    }

        //    return RedirectToAction(nameof(ViewAllClubs));
        //}
    }
}
