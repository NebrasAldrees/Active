using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;
using Nashet.Data.Models;
using Nashet.Models;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nashet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KfuUserDomain _kfuUserDomain;
        private readonly UserDomain _UserDomain;

        public HomeController(ILogger<HomeController> logger, KfuUserDomain kfuUserDomain, UserDomain userDomain)
        {
            _logger = logger;
            _kfuUserDomain = kfuUserDomain;
            _UserDomain = userDomain;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(string Username, string Password)
        //{
        //    try
        //    {
        //        var KfuUser = await _kfuUserDomain.CheckUser(Username, Password);
        //        if (KfuUser != null)
        //        {
        //            if (KfuUser.UserType != "9")
        //            {
        //                var user = await _UserDomain.GetUserByUsername(Username);
        //                if (user != null)
        //                {
        //                    var identity = new ClaimsIdentity(new[]
        //                    {
        //                new Claim(ClaimTypes.Name, user.Username),
        //                new Claim(ClaimTypes.Role, user.SystemRoleType),
        //                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
        //                new Claim(ClaimTypes.GivenName, user.UserNameAR)
        //            }, CookieAuthenticationDefaults.AuthenticationScheme);
        //                    var principal = new ClaimsPrincipal(identity);

        //                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
        //                        principal);

        //                    if (user.SystemRoleType == "„œÌ— «·‰Ÿ«„")
        //                        return RedirectToAction("Index", "Home", new { area = "Admin" });
        //                    else if (user.SystemRoleType == "„‘—› «·√‰‘ÿ…")
        //                        return RedirectToAction("ActivitiesSupervisorHome", "Home", new { area = "ActivitiesSupervisor" });
        //                    else if (user.SystemRoleType == "„‘—› «·‰«œÌ")
        //                        return RedirectToAction("Index", "Home", new { area = "ClubSupervisor" });
        //                    else if (user.SystemRoleType == "ÿ«·»")
        //                        return RedirectToAction("Index", "Home", new { area = "Student" });
        //                    else if (user.SystemRoleType == "ﬁ«∆œ «·‰«œÌ")
        //                        return RedirectToAction("Index", "Home", new { area = "ClubLeader" });
        //                }
        //                else
        //                {
        //                    ViewData["Login_Error"] = "Œÿ√ «”„ «·„” Œœ„ «Ê ﬂ·„… «·„—Ê— €Ì— ’ÕÌÕ…";
        //                    return View();
        //                }
        //            }
        //            else
        //            {
        //                ViewData["Login_Error"] = "Œÿ√ «”„ «·„” Œœ„ «Ê ﬂ·„… «·„—Ê— €Ì— ’ÕÌÕ…";
        //                return View();
        //            }
        //        }
        //        else
        //        {
        //            ViewData["Login_Error"] = "Œÿ√ «”„ «·„” Œœ„ «Ê ﬂ·„… «·„—Ê— €Ì— ’ÕÌÕ…";
        //            return View();
        //        }
        //        return View();
        //    }
        //    catch
        //    {
        //        ViewData["Login_Error"] = "Œÿ√ «”„ «·„” Œœ„ «Ê ﬂ·„… «·„—Ê— €Ì— ’ÕÌÕ…";
        //        return View();
        //    }
        //}
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
        public IActionResult users()
        {
            return View();
        }
        public IActionResult InsertUser()
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class LoginVIewModel
    {
    }
}
