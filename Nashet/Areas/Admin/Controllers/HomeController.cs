using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Data.Models;
using Nashet.Models;
using System.Diagnostics;

namespace Nashet.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserDomain _userDomain;

        public HomeController(ILogger<HomeController> logger, UserDomain userDomain)
        {
            _logger = logger;
            _userDomain = userDomain;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UpdateUserRole()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ViewUsers()
        {
            return View(await _userDomain.GetUser());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> InsertUser(tblUser User)
        {
            try
            {
                int check = await _userDomain.InsertUser(User);
                if (check == 1)
                    ViewBag.Successful = "Successful";
                else
                    ViewBag.Failed = "Failed";
            }
            catch { }
            return View(User);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
