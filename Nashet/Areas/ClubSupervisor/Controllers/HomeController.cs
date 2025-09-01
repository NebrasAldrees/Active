using Microsoft.AspNetCore.Mvc;

namespace Nashet.Areas.ClubSupervisor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
