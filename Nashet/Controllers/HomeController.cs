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
        private readonly StudentDomain _StudentDomain;

        public HomeController(ILogger<HomeController> logger, KfuUserDomain kfuUserDomain, UserDomain userDomain, StudentDomain studentDomain)
        {
            _logger = logger;
            _kfuUserDomain = kfuUserDomain;
            _UserDomain = userDomain;
            _StudentDomain = studentDomain;
        }
        public IActionResult AccessDenied()
        {
            return View();
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
        public async Task<IActionResult> Login(string Username, string Password)
        {
            try
            {
                var kfuUser = await _kfuUserDomain.CheckUser(Username, Password);

                if (kfuUser == null)
                {
                    kfuUser = await _kfuUserDomain.CheckUserByEmail(Username, Password);
                }

                if (kfuUser == null)
                {
                    ViewData["Login_Error"] = "«”„ «·„” Œœ„/«·≈Ì„Ì· √Ê ﬂ·„… «·„—Ê— €Ì— ’ÕÌÕ…";
                    return View();
                }

                if (kfuUser.UserType != "Student")
                {
                    var user = await _UserDomain.GetUserByUsername(kfuUser.Username);
                    if (user == null)
                    {
                        ViewData["Login_Error"] = "«·„” Œœ„ €Ì— „”Ã· ›Ì «·‰Ÿ«„";
                        return View();
                    }
                }

                if (kfuUser.UserType == "Student")
                {
                    var student = await _StudentDomain.GetStudentByEmail(kfuUser.UserEmail);
                    if (student == null)
                    {
                        ViewData["Login_Error"] = "«·ÿ«·» €Ì— „”Ã· ›Ì «·‰Ÿ«„";
                        return View();
                    }
                }

                var identity = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, kfuUser.Username),
            new Claim(ClaimTypes.Role, kfuUser.UserType),
            new Claim(ClaimTypes.NameIdentifier, kfuUser.KFUUserId.ToString()),
            new Claim(ClaimTypes.GivenName, kfuUser.NameAR ?? kfuUser.NameEN),
            new Claim(ClaimTypes.Email, kfuUser.UserEmail)
        },
                CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                if (kfuUser.UserType == "Admin")
                {
                    return RedirectToAction("AdminHome", "Home", new { area = "Admin" });
                }
                else if (kfuUser.UserType == "ActivitySupervisor")
                {
                    return RedirectToAction("ActivitiesSupervisorHome", "Home", new { area = "ActivitiesSupervisor" });
                }
                else if (kfuUser.UserType == "ClubSupervisor")
                {
                    return RedirectToAction("ClubSupervisorHome", "Home", new { area = "ClubSupervisor" });
                }
                else if (kfuUser.UserType == "Student")
                {
                    return RedirectToAction("StudentHome", "Home", new { area = "Student" });
                }
                else
                {
                    ViewData["Login_Error"] = "‰Ê⁄ «·„” Œœ„ €Ì— „œ⁄Ê„";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewData["Login_Error"] = "ÕœÀ Œÿ√ √À‰«¡  ”ÃÌ· «·œŒÊ·";
                return View();
            }
        }
        [HttpGet]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
        public IActionResult ProfilePage()
        {
            return View();
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
