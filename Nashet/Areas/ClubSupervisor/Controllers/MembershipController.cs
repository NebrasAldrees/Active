using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.ClubSupervisor.Controllers
{

    [Area("ClubSupervisor")]
    public class MembershipController : Controller
    {
        private readonly MembershipDomain _MembershipDomain;
        private readonly TeamDomain _TeamDomain;
        private readonly StudentDomain _StudentDomain;
        private readonly ClubRoleDomain _ClubRoleDomain;
        public MembershipController(MembershipDomain MembershipDomain, TeamDomain teamDomain, StudentDomain studentDomain, ClubRoleDomain clubRoleDomain)
        {
            _MembershipDomain = MembershipDomain;
            _TeamDomain = teamDomain;
            _StudentDomain = studentDomain;
            _ClubRoleDomain = clubRoleDomain;
        }
        public async Task<IActionResult> ViewMember()
        {
            return View(await _MembershipDomain.GetMembership());
        }
        public async Task<IActionResult> InsertMember()
        {
            ViewBag.Team = await _TeamDomain.GetTeam();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchStudent(String academicId)
        {
            var student = await _StudentDomain.GetByAcademicId(academicId); 
            if (student == null)
            {
                ViewData["Error"] = "لم يتم العثور على الطالب";
                return View("InsertMember"); 
            }

            var viewModel = new MembershipViewModel
            {
                AcademicId = student.AcademicId,
                StudentId = student.StudentId,
                Student = student,
            };

            ViewBag.Team = await _TeamDomain.GetTeam();
            return View("InsertMember", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertMember(MembershipViewModel viewModel)
        {
            ViewBag.Team = await _TeamDomain.GetTeam();
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _MembershipDomain.InsertMembership(viewModel);
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

        public IActionResult Index()
        {
            return View();
        }
    }
}


