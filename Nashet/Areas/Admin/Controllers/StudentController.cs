using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;
using Nashet.Models;
using System.Diagnostics;

namespace Nashet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

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
        public async Task<IActionResult> ViewStudentByGuid(Guid Guid)
        {
            return View(await _StudentDomain.GetStudentByGuid(Guid));
        }

        
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
                    {
                        ViewData["Successful"] = "تمت إضافة الطالب بنجاح ✅";
                        return View(new StudentViewModel()); // إرجاع نموذج جديد
                    }
                    else
                    {
                        ViewData["Failed"] = "فشل في إضافة الطالب ❌";
                    }
                }
                catch
                {
                    ViewData["Failed"] = "حدث خطأ أثناء الإضافة ❌";
                }
            }
            else
            {
                ViewData["Failed"] = "البيانات المدخلة غير صالحة ❌";
            }

            return View(viewModel);
        }

        public async Task<IActionResult> UpdateStudent(Guid Guid)
        {
            try
            {
                var student = await _StudentDomain.GetStudentByGuid(Guid);
                if (student == null)
                {
                    TempData["Error"] = "الطالب غير موجود";
                    return RedirectToAction(nameof(ViewStudents));
                }

                var viewModel = new StudentViewModel
                {
                    Guid = student.Guid,
                   StudentNameAr = student.StudentNameAr,
                   StudentNameEn = student.StudentNameEn,
                    AcademicId = student.AcademicId,
                    StudentEmail = student.StudentEmail,
                    StudentPhone = student.StudentPhone,
                    StudentSkills = student.StudentSkills,
                    SiteId = student.SiteId,
                };

                return View(viewModel);
            }
            catch
            {
                return RedirectToAction(nameof(ViewStudents));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStudent(StudentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _StudentDomain.UpdateStudent(viewModel);
                    if (check == 1)
                    {
                        TempData["Message"] = "تم تعديل بيانات الطالب بنجاح";
                        return RedirectToAction(nameof(ViewStudents));
                    }
                    else
                        TempData["Error"] = "فشل التعديل";
                }
                catch
                {
                    TempData["Error"] = "فشل التعديل";
                }
            }
            return View(viewModel);
        }
        public async Task<ActionResult> DeleteStudent(Guid Guid)
        {
            int result = await _StudentDomain.DeleteStudent(Guid);

            if (result == 1)
            {
                TempData["Success"] = "تم حذف الطالب بنجاح";
            }
            else
            {
                TempData["Error"] = "خطأ في الحذف";
            }

            return RedirectToAction("ViewStudents");
        }

    } 
}