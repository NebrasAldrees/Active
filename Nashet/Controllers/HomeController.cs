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
                // 1. «· Õﬁﬁ „‰ «·„” Œœ„ ›Ì KFU
                var KfuUser = await _kfuUserDomain.CheckUser(Username, Password);

                // 2. ≈–« ·„ ÌÃœÂ »«·«”„° Ã—» «·»ÕÀ »«·≈Ì„Ì·
                if (KfuUser == null)
                {
                    KfuUser = await _kfuUserDomain.CheckUserByEmail(Username, Password);
                }

                if (KfuUser != null)
                {
                    // 3. «· Õﬁﬁ „‰ «·„” Œœ„ ›Ì ÃœÊ· User
                    var user = await _UserDomain.GetUserByUsername(KfuUser.Username);
                    if (user != null)
                    {
                        // 4. ≈–« ﬂ«‰ «·„” Œœ„ ÿ«·»°  Õﬁﬁ „‰ ÊÃÊœÂ ›Ì ÃœÊ· Student
                        if (user.RoleTypeEn == "Student")
                        {
                            var student = await _StudentDomain.GetStudentByEmail(user.UserEmail);
                            if (student == null)
                            {
                                ViewData["Login_Error"] = "«·ÿ«·» €Ì— „”Ã· ›Ì «·‰Ÿ«„";
                                return View();
                            }
                        }

                        // 4. ≈‰‘«¡ «·‹ Claims Ê ”ÃÌ· «·œŒÊ·
                        var identity = new ClaimsIdentity(new[]
                        {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.RoleTypeEn),
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.GivenName, user.UserNameAR),
                    new Claim(ClaimTypes.Email, user.UserEmail)
                },
                        CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        // 5. «· ÊÃÌÂ Õ”» «·œÊ—
                        if (user.RoleTypeEn == "Admin")
                            return RedirectToAction("AdminHome", "Home", new { area = "Admin" });
                        else if (user.RoleTypeEn == "ActivitySupervisor")
                            return RedirectToAction("ActivitiesSupervisorHome", "Home", new { area = "ActivitiesSupervisor" });
                        else if (user.RoleTypeEn == "ClubSupervisor")
                            return RedirectToAction("ClubSupervisorHome", "Home", new { area = "ClubSupervisor" });
                        else if (user.RoleTypeEn == "Student")
                            return RedirectToAction("StudentHome", "Home", new { area = "Student" });
                    }
                    else
                    {
                        ViewData["Login_Error"] = "«·„” Œœ„ €Ì— „”Ã· ›Ì «·‰Ÿ«„";
                        return View();
                    }
                }
                else
                {
                    ViewData["Login_Error"] = "Œÿ√ ›Ì «”„ «·„” Œœ„ √Ê ﬂ·„… «·„—Ê—";
                    return View();
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewData["Login_Error"] = "ÕœÀ Œÿ√ √À‰«¡  ”ÃÌ· «·œŒÊ·";
                return View();
            }
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(string Username, string Password)
        //{
        //    try
        //    {
        //        // 1. «· Õﬁﬁ „‰ «·„” Œœ„ ›Ì KFU
        //        var KfuUser = await _kfuUserDomain.CheckUser(Username, Password);
        //        if (KfuUser != null)
        //        {
        //            // 2. «· Õﬁﬁ „‰ «·„” Œœ„ ›Ì ÃœÊ· User
        //            var user = await _UserDomain.GetUserByUsername(Username);
        //            if (user != null)
        //            {
        //                // 3. ≈–« ﬂ«‰ «·„” Œœ„ ÿ«·»°  Õﬁﬁ „‰ ÊÃÊœÂ ›Ì ÃœÊ· Student
        //                if (user.RoleTypeEn == "Student")
        //                {
        //                    var student = await _StudentDomain.GetStudentByEmail(user.UserEmail);
        //                    if (student == null)
        //                    {
        //                        ViewData["Login_Error"] = "«·ÿ«·» €Ì— „”Ã· ›Ì «·‰Ÿ«„";
        //                        return View();
        //                    }
        //                }

        //                // 4. ≈‰‘«¡ «·‹ Claims Ê ”ÃÌ· «·œŒÊ·
        //                var identity = new ClaimsIdentity(new[]
        //                {
        //            new Claim(ClaimTypes.Name, user.Username),
        //            new Claim(ClaimTypes.Role, user.RoleTypeEn),
        //            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
        //            new Claim(ClaimTypes.GivenName, user.UserNameAR),
        //            new Claim(ClaimTypes.Email, user.UserEmail)
        //        },
        //                CookieAuthenticationDefaults.AuthenticationScheme);
        //                var principal = new ClaimsPrincipal(identity);

        //                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        //                // 5. «· ÊÃÌÂ Õ”» «·œÊ—
        //                if (user.RoleTypeEn == "Admin")
        //                    return RedirectToAction("AdminHome", "Home", new { area = "Admin" });
        //                else if (user.RoleTypeEn == "ActivitySupervisor")
        //                    return RedirectToAction("ActivitiesSupervisorHome", "Home", new { area = "ActivitiesSupervisor" });
        //                else if (user.RoleTypeEn == "ClubSupervisor")
        //                    return RedirectToAction("ClubSupervisorHome", "Home", new { area = "ClubSupervisor" });
        //                else if (user.RoleTypeEn == "Student")
        //                    return RedirectToAction("StudentHome", "Home", new { area = "Student" });
        //            }
        //            else
        //            {
        //                ViewData["Login_Error"] = "«·„” Œœ„ €Ì— „”Ã· ›Ì «·‰Ÿ«„";
        //                return View();
        //            }
        //        }
        //        else
        //        {
        //            ViewData["Login_Error"] = "Œÿ√ ›Ì «”„ «·„” Œœ„ √Ê ﬂ·„… «·„—Ê—";
        //            return View();
        //        }
        //        return View();
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewData["Login_Error"] = "ÕœÀ Œÿ√ √À‰«¡  ”ÃÌ· «·œŒÊ·";
        //        return View();
        //    }
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(string Username, string Password)
        //{
        //    try
        //    {
        //        var KfuUser = await _kfuUserDomain.CheckUser(Username, Password);
        //        if (KfuUser != null)
        //        {
        //            if (KfuUser.UserType != "Staff")
        //            {
        //                var user = await _UserDomain.GetUserByUsername(Username);
        //                if (user != null)
        //                {
        //                    var identity = new ClaimsIdentity(new[]
        //                    {
        //                new Claim(ClaimTypes.Name, user.Username),
        //                new Claim(ClaimTypes.Role, user.RoleTypeEn),
        //                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
        //                new Claim(ClaimTypes.GivenName, user.UserNameAR)
        //            },
        //            CookieAuthenticationDefaults.AuthenticationScheme);
        //                    var principal = new ClaimsPrincipal(identity);

        //                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
        //                        principal);

        //                    if (user.RoleTypeEn == "Admin")
        //                        return RedirectToAction("AdminHome", "Home", new { area = "Admin" });
        //                    else if (user.RoleTypeEn == "ActivitySupervisor")
        //                        return RedirectToAction("ActivitiesSupervisorHome", "Home", new { area = "ActivitiesSupervisor" });
        //                    else if (user.RoleTypeEn == "ClubSupervisor")
        //                        return RedirectToAction("ClubsupervisorHome", "Home", new { area = "ClubSupervisor" });
        //                    else if (user.RoleTypeEn == "Student")
        //                        return RedirectToAction("StudentHome", "Home", new { area = "Student" });
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
