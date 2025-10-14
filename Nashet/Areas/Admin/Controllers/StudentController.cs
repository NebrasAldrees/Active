using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;
using Nashet.Models;
using System.Diagnostics;

namespace Nashet.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class StudentController : Controller
    {
        private readonly StudentDomain _StudentDomain;
        private readonly SiteDomain _Siteomain;
        public StudentController(StudentDomain studentDomain, SiteDomain siteDomain)
        {
            _StudentDomain = studentDomain;
            _Siteomain = siteDomain;
        }

        public async Task<IActionResult> ViewStudents()
        {
            return View(await _StudentDomain.GetStudent());
        }

        [HttpGet]
        public async Task<IActionResult> InsertStudent()
        {
            ViewBag.Site = await _Siteomain.GetSite();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertStudent(StudentViewModel viewModel)
        {
            ViewBag.Site = await _Siteomain.GetSite();

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
            return RedirectToAction("ViewStudents");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStudent(int id, StudentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _StudentDomain.UpdateStudent(id, viewModel);
                    if (check == 1)
                        ViewData["Successful"] = "Student Update successfully.";
                    else
                        ViewData["Failed"] = "تم تعديل بيانات الطالب بنجاح";
                }
                catch
                {
                    ViewData["Failed"] = "فشل التعديل";
                }
            }
            return RedirectToAction("ViewStudents");
        }
        //public async Task<ActionResult> DeleteStudent(int id)
        //{
        //    int result = await _StudentDomain.DeleteStudent(id);

        //    if (result == 1)
        //    {
        //        TempData["Success"] = "تم حذف الجهة بنجاح";
        //    }
        //    else
        //    {
        //        TempData["Error"] = "خطأ في الحذف";
        //    }

        //    return RedirectToAction("ViewStudent");
        //}



    }


    //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //public IActionResult Error()
    //{
    //    return View(new ErrorViewModel { RequestId = Students.Current?.Id ?? HttpContext.TraceIdentifier });
    //}
}

