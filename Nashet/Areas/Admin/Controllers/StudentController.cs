using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly StudentDomain _StudentDomain;
        public StudentController(StudentDomain studentDomain)
        {
            _StudentDomain = studentDomain;
        }
        public async Task<IActionResult> ViewStudent()
        {
            return View(await _StudentDomain.GetStudent());
        }
        public async Task<IActionResult> InsertStudent()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertStudent(StudentViewModel viewModel)
        {
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
