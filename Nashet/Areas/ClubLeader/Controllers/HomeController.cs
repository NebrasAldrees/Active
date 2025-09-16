using Microsoft.AspNetCore.Mvc;

namespace Nashet.Areas.ClubLeader.Controllers
{
    [Area("ClubLeader")]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
