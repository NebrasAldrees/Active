using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly StudentDomain _StudentDomain;
        private readonly SiteDomain _SiteDomain;
        public StudentController(StudentDomain studentDomain ,SiteDomain siteDomain)
        {
            _StudentDomain = studentDomain;
            _SiteDomain = siteDomain;
        }
        public async Task<IActionResult> ViewStudent()
        {
            return View(await _StudentDomain.GetStudent());
        }
        public async Task<IActionResult> InsertStudent()
        {
            ViewBag.Site = await _SiteDomain.GetSite();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertStudent(StudentViewModel viewModel)
        {
            ViewBag.Site = await _StudentDomain.GetStudent();
           
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _StudentDomain.InsertStudent(viewModel);
                    if (check == 1)
                        ViewData["Successful"] = "Successful";
                    else
                        ViewData["Failed"] = "Failed";
                }
                catch
                {
                    ViewData["Failed"] = "Failed";
                }
            }
            return View(viewModel);
        }


    }
}
