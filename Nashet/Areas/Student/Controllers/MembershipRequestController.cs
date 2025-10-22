using Microsoft.AspNetCore.Mvc;

namespace Nashet.Areas.Student.Controllers
{
    [Area("Student")]
    public class MembershipRequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
