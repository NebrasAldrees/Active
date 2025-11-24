using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

using Nashet.Business.Domain;

using Nashet.Business.ViewModels;

[Area("Admin")]

[Authorize(Roles = "Admin")]

public class UserController : Controller

{

    private readonly UserDomain _domain;

    private readonly SystemRoleDomain _systemRoleDomain;

    private readonly SiteDomain _siteDomain;

    public UserController(UserDomain domain, SystemRoleDomain systemRoleDomain, SiteDomain siteDomain)

    {

        _domain = domain;

        _systemRoleDomain = systemRoleDomain;

        _siteDomain = siteDomain;

    }

    [HttpGet]

    public async Task<IActionResult> ViewUser()

    {

        return View(await _domain.GetUser());

    }

    [HttpGet]

    public async Task<IActionResult> InsertUser()

    {

        ViewBag.Site = await _siteDomain.GetSite();

        ViewBag.SystemRole = await _systemRoleDomain.GetSystemRole();

        return View();

    }

    [HttpPost]

    [ValidateAntiForgeryToken]

    public async Task<IActionResult> InsertUser(UserViewModel viewModel)

    {

        ViewBag.Site = await _siteDomain.GetSite();

        ViewBag.SystemRole = await _systemRoleDomain.GetSystemRole();

        if (ModelState.IsValid)
        {

            int check = await _domain.InsertUser(viewModel);

            if (check == 1)

            {

                TempData["Successful"] = "تمت الإضافة بنجاح ✅";

                return RedirectToAction("ViewUser"); // ✅ يرجع للقائمة

            }

            TempData["Failed"] = "فشلت العملية ❌";

        }

        else

        {

            // اطبع الأخطاء عشان تعرف السبب

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);

            TempData["Failed"] = "البيانات غير صالحة ❌: " + string.Join(", ", errors);

        }

        return View(viewModel);

    }



    [HttpPost]

    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Delete(int id)

    {

        bool check = await _domain.DeleteUser(id);

        TempData["Successful"] = check == true ? "تم الحذف بنجاح ✅" : "فشلت عملية الحذف ❌";

        return RedirectToAction("ViewUser");

    }

}

