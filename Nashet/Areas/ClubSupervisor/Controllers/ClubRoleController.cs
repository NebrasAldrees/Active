using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.ClubSupervisor.Controllers
{
    [Area("ClubLeader")]
    [Authorize(Roles = "ClubSupervisor")]
    public class ClubRoleController : Controller
    {
        private readonly ClubRoleDomain _ClubRoleDomain;
        public ClubRoleController(ClubRoleDomain clubroleDomain)
        {
            _ClubRoleDomain = clubroleDomain;
        }
        public async Task<IActionResult> ViewClubRole()
        {
            return View(await _ClubRoleDomain.GetClubRole());
        }
        [HttpGet]
        public async Task<IActionResult> ViewClubRoleByGuid(Guid Guid)
        {
            return View(await _ClubRoleDomain.GetClubRoleByGuid(Guid));
        }
        public async Task<IActionResult> InsertClubRole()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertClubRole(ClubRoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _ClubRoleDomain.InsertClubRole(viewModel);
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

        public async Task<IActionResult> UpdateClubRole(Guid Guid)
        {
            try
            {
                var clubrole = await _ClubRoleDomain.GetClubRoleByGuid(Guid);
                if (clubrole == null)
                {
                    TempData["Error"] = "الطالب غير موجود";
                    return RedirectToAction(nameof(ViewClubRole));
                }

                var viewModel = new ClubRoleViewModel
                {
                    Guid = clubrole.Guid,
                    ClubRoleId = clubrole.ClubRoleId,
                    RoleTypeAr = clubrole.RoleTypeAr,
                    RoleTypeEn = clubrole.RoleTypeEn,
                };

                return View(viewModel);
            }
            catch
            {
                return RedirectToAction(nameof(UpdateClubRole));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateClubRole(ClubRoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _ClubRoleDomain.UpdateClubRole(viewModel);
                    if (check == 1)
                    {
                        TempData["Message"] = "تم تعديل بيانات منصب النادي بنجاح";
                        return RedirectToAction(nameof(UpdateClubRole));
                    }
                    else
                        TempData["Error"] = "فشل التعديل";
                }
                catch
                {
                    TempData["Error"] = "فشل التعديل";
                }
            }
            return View(viewModel);
        }
        public async Task<ActionResult> DeleteClubRole (Guid Guid)
        {
            int result = await _ClubRoleDomain.DeleteClubRole(Guid);

            if (result == 1)
            {
                TempData["Success"] = "تم حذف المنصب بنجاح";
            }
            else
            {
                TempData["Error"] = "خطأ في الحذف";
            }

            return RedirectToAction("ClubRole");
        }
    }
}
