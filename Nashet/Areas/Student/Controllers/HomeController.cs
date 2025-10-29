using Microsoft.AspNetCore.Mvc;

namespace Nashet.Areas.Student.Controllers
{
    [Area("Student")]
    public class HomeController : Controller
    {
        public IActionResult StudentHome()
        {
            return View();
        }
    }
}
