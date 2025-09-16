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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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
