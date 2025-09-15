using System.Diagnostics;
using System.Threading.Tasks;
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
        private readonly UserDomain _userDomain;

        public HomeController(ILogger<HomeController> logger,MembershipDomain  membershipDomain, UserDomain userDomain)
        {
            _logger = logger;
            _membershipDomain = membershipDomain;
            _userDomain = userDomain;
        }

        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult Login()
        //{
        //    return View();
        //}
        //public async Task<IActionResult> Login(LoginVIewModel)
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult users()
        {
            return View();
        }

        public IActionResult add_order()
        {
            return View();
        }
        public IActionResult orders()
        {
            return View();
        }
        public IActionResult rules()
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

        //public async Task<IActionResult> User()
        //{
        //    return View(await _userDomain.GetUser());
        //}
        //public IActionResult InsertUser()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> InsertUser(tblUser User)
        //{
        //    try
        //    {
        //        int check = await _userDomain.InsertUser(User);
        //        if (check == 1)
        //            ViewBag.Successful = "Successful";
        //        else
        //            ViewBag.Failed = "Failed";
        //    }
        //    catch { }
        //    return View(User);
        //}

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class LoginVIewModel
    {
    }
}
