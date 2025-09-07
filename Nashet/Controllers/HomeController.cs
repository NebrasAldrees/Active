using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Nashet.Business.Domain;
using Nashet.Data.Models;
using Nashet.Models;

namespace Nashet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MembershipDomain _membershipDomain;

        public HomeController(ILogger<HomeController> logger,MembershipDomain  membershipDomain)
        {
            _logger = logger;
            _membershipDomain = membershipDomain;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
       // public async Task<IActionResult> Login(LoginVIewModel)
       //{
       //     return View();
       // }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult InsertMember()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult>  InsertMember(tblMembership Member)
        {
            try
            {
                int check = await _membershipDomain.InsertMember(Member);
                if (check == 1)
                    ViewBag.Successful = "Successful";
                else
                    ViewBag.Failed = "Failed";
            }
            catch { }
            return View(Member);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
