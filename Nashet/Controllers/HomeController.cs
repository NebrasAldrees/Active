using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        private readonly KfuUserDomain _kfuUserDomain;
        private readonly UserDomain _UserDomain;

        public HomeController(ILogger<HomeController> logger,KfuUserDomain kfuUserDomain, UserDomain userDomain)
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
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(String UserName, String Password)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
        //        {
        //            ViewData["Login_Error"] = "Ì—ÃÏ ≈œŒ«· «”„ «·„” Œœ„ Êﬂ·„… «·„—Ê—";
        //            return View();
        //        }

        //        var KfuUser = await _kfuUserDomain.CheckUser(UserName, Password);
        //        if (KfuUser != null && KfuUser.UserType != "Student")
        //        {
        //            var user = await _UserDomain.GetUserByUsername(UserName);
        //            if (user != null)
        //            {
        //                var identity = new ClaimsIdentity(new[]
        //                {
        //            new Claim(ClaimTypes.Name, user.Username),
        //            new Claim(ClaimTypes.Role, user.RoleName),
        //            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
        //            new Claim(ClaimTypes.GivenName, user.UserNameAR)
        //        }, CookieAuthenticationDefaults.AuthenticationScheme);

        //                var principal = new ClaimsPrincipal(identity);
        //                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        //                // Redirect based on role
        //                return user.RoleName switch
        //                {
        //                    "Admin" => RedirectToAction("Index", "Home", new { area = "Admin" }),
        //                    "ActivitiesSupervisor" => RedirectToAction("Index", "Home", new { area = "ActivitiesSupervisor" }),
        //                    "ClubSupervisor" => RedirectToAction("Index", "Home", new { area = "ClubSupervisor" }),
        //                    "Student" => RedirectToAction("Index", "Home", new { area = "Student" }),
        //                    "ClubLeader" => RedirectToAction("Index", "Home", new { area = "ClubLeader" }),
        //                    _ => RedirectToAction("Index", "Home")
        //                };
        //            }
        //        }

        //        ViewData["Login_Error"] = "Œÿ√ ›Ì «”„ «·„” Œœ„ √Ê ﬂ·„… «·„—Ê—";
        //        return View();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Login error for user {UserName}", UserName);
        //        ViewData["Login_Error"] = "ÕœÀ Œÿ√ √À‰«¡ ⁄„·Ì… «· ”ÃÌ·";
        //        return View();
        //    }
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(String Username, String Password)
        {
            try
            {
                var KfuUser = await _kfuUserDomain.CheckUser(Username, Password);
                if (KfuUser != null)
                {
                    if (KfuUser.UserType != "Sttuf")
                    {
                        var user = await _UserDomain.GetUserByUsername(Username);
                        if (user != null)
                        {
                            var identity = new ClaimsIdentity(new[]
                            {
                                new Claim(ClaimTypes.Name, user.Username),
                                new Claim(ClaimTypes.Role, user.RoleName),
                                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                                new Claim(ClaimTypes.GivenName, user.UserNameAR)
                            }, CookieAuthenticationDefaults.AuthenticationScheme);
                            var principal = new ClaimsPrincipal(identity);

                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                principal);
                            if (user.RoleName == "Admin")
                                return RedirectToAction("Index", "Home", new { area = "Admin" });
                            else if (user.RoleName == "ActivitiesSupervisor")
                                return RedirectToAction("Index", "Home", "ActivitiesSupervisor");
                            else if (user.RoleName == "ClubSupervisor")
                                return RedirectToAction("Index", "Home", "ClubSupervisor");
                            else if (user.RoleName == "Student")
                                return RedirectToAction("Index", "Home", new { area = "Student" });
                            else if (user.RoleName == "ClubLeader")
                                return RedirectToAction("Index", "Home", "ClubLeader");
                        }
                        else
                        {
                            ViewData["Login_Error"] = "Õÿ√ «”„ «·„” Œœ„ «Ê ﬂ·„… «·„—Ê— €Ì— ’ÕÌÕ…";
                            return View();
                        }
                    }
                    else
                    {
                        ViewData["Login_Error"] = "Õÿ√ «”„ «·„” Œœ„ «Ê ﬂ·„… «·„—Ê— €Ì— ’ÕÌÕ…";
                        return View();
                    }
                }
                else
                {
                    ViewData["Login_Error"] = "Õÿ√ «”„ «·„” Œœ„ «Ê ﬂ·„… «·„—Ê— €Ì— ’ÕÌÕ…";
                    return View();
                }
                return View();
            }
            catch
            {
                ViewData["Login_Error"] = "Õÿ√ «”„ «·„” Œœ„ «Ê ﬂ·„… «·„—Ê— €Ì— ’ÕÌÕ…";
                return View();
            }
        }
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
