using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class SystemRoleController : Controller
    {
        private readonly SystemRoleDomain _domain;
        public SystemRoleController(SystemRoleDomain domain)
        {
            _domain = domain;
        }
        public async Task<IActionResult> ViewSystemRole()
        {
            return View(await _domain.GetSystemRole());
        }
        public async Task<IActionResult> Insert()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertSystemRole(SystemRoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _domain.InsertSystemRole(viewModel);
                    if (check == 1)
                    {
                        return Json(new { success = true, message = "تم إضافة دور بنجاح" });
                    }
                    else
                    {
                        return Json(new { success = false, message = "لم يتم العثور على الدور أو فشل الإضافة" });
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "حدث خطأ أثناء الإضافة: " + ex.Message });
                }
            }
            return View("Insert", viewModel);
        }
        public async Task<IActionResult> UpdateSystemRole(Guid Guid)
        {
            try
            {
                var role = await _domain.GetSystemRoleByGuid(Guid);
                if (role == null)
                {
                    ViewData["Error"] = "المنصب غير موجود";
                    return RedirectToAction(nameof(ViewSystemRole));
                }

                var viewModel = new SystemRoleViewModel
                {
                    guid = role.Guid,
                    SystemRoleId = role.SystemRoleId,
                    RoleTypeAr = role.RoleTypeAr,
                    RoleTypeEn = role.RoleTypeEn,
                };
                ViewData["Successful"] = "تم التحديث بنجاح";
                return View(viewModel);
            }
            catch
            {
                ViewData["Failed"] = "فشل في التحديث";
                return RedirectToAction(nameof(UpdateSystemRole));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSystemRole(SystemRoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _domain.UpdateSystemRole(viewModel);
                    if (check == 1)
                    {
                        ViewData["Message"] = "تم تعديل بيانات منصب النادي بنجاح";
                        return RedirectToAction(nameof(ViewSystemRole));
                    }
                    else
                        ViewData["Error"] = "فشل التعديل";
                }
                catch
                {
                    ViewData["Error"] = "فشل التعديل";
                }
            }
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteSystemRole(Guid guid)
        {
            try
            {
                int result = await _domain.DeleteSystemRole(guid);

                if (result == 1)
                {
                    return Json(new { success = true, message = "تم حذف الجهة بنجاح" });
                }
                else
                {
                    return Json(new { success = false, message = "لم يتم العثور على الجهة أو فشل الحذف" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "حدث خطأ أثناء الحذف: " + ex.Message });
            }
        }
    }
}