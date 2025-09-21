using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.Admin.Controllers
{

    [Area("Admin")]
   
        public class UserController : Controller
        {
            private readonly UserDomain _domain;
            public UserController(UserDomain domain)
            {
                _domain = domain;
            }

            public async Task<IActionResult> Index()
            {
                return View(await _domain.GetGetUser());
            }
            public async Task<IActionResult> Insert()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Insert(UserViewModel viewModel)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        int check = await _domain.InsertUser(viewModel);
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

