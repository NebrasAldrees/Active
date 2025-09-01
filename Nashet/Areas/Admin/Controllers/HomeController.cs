using Microsoft.AspNetCore.Mvc;

namespace Nashet.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
