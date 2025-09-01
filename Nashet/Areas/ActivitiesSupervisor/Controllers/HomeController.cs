using Microsoft.AspNetCore.Mvc;

namespace Nashet.Areas.ActivitiesSupervisor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
