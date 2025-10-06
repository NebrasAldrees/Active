using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.Admin.Controllers
{

    [Area("Admin")]
   
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

            public async Task<IActionResult> Index()
            {
                return View(await _domain.GetUser());
            }


        public async Task<IActionResult> InsertUser()
        {
            var viewModel = await CreateUserViewModelWithDropdowns();
            return View(viewModel);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> InsertUser()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> InsertUser(UserViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            int check = await _domain.InsertUser(viewModel);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertUser(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _domain.InsertUser(viewModel);
                    if (check == 1)
                    {
                        TempData["Successful"] = "تم الحفظ بنجاح";
                        return RedirectToAction(nameof(InsertUser));
                    }
                    else
                    {
                        TempData["Failed"] = "فشل في الحفظ";
                    }
                }
                catch (Exception ex)
                {
                    TempData["Failed"] = $"حدث خطأ: {ex.Message}";
                }
            }
            else
            {
                TempData["Failed"] = "البيانات غير صالحة";
            }

            // Repopulate dropdowns and return with errors
            var updatedViewModel = await CreateUserViewModelWithDropdowns();
            updatedViewModel.UserNameAR = viewModel.UserNameAR;
            updatedViewModel.UserNameEN = viewModel.UserNameEN;
            updatedViewModel.Username = viewModel.Username;
            updatedViewModel.UserEmail = viewModel.UserEmail;
            updatedViewModel.UserPhone = viewModel.UserPhone;
            updatedViewModel.SiteId = viewModel.SiteId;
            updatedViewModel.SystemRoleId = viewModel.SystemRoleId;

            return View(updatedViewModel);
        }

        private async Task<UserViewModel> CreateUserViewModelWithDropdowns()
        {
            return new UserViewModel
            {
                SystemRoles = (await _systemRoleDomain.GetSystemRole())?.ToList() ?? new List<SystemRoleViewModel>(),
                Sites = (await _siteDomain.GetSite())?.ToList() ?? new List<SiteViewModel>()
            };
        }

    }
}

