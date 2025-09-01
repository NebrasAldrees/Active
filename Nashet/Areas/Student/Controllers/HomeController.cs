using Microsoft.AspNetCore.Mvc;

namespace Nashet.Areas.Student.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
