using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

[Area("Student")]
[Authorize(Roles = "Student")]
public class MembershipRequestController : Controller
{
    private readonly MembershipRequestDomain _domain;
    private readonly ClubDomain _ClubDomain;
    private readonly TeamDomain _TeamDomain;
    private readonly StudentDomain _StudentDomain;


    public MembershipRequestController(MembershipRequestDomain domain, ClubDomain clubDomain, TeamDomain teamDomain, StudentDomain studentDomain)
    {
        _domain = domain;
        _ClubDomain = clubDomain;
        _TeamDomain = teamDomain;
        _StudentDomain = studentDomain;
    }

    public async Task<IActionResult> InsertMembershipRequest()
    {
        var username = User.Identity?.Name;
        var student = await _StudentDomain.GetByAcademicId(username);

        ViewBag.Club = await _ClubDomain.GetClub();
        ViewBag.Team = await _TeamDomain.GetTeam();
        ViewBag.StudentNameAr = student.StudentNameAr;
        ViewBag.AcademicId = student.AcademicId;

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetTeamByClubGuid(Guid id)
    {
        var teams = await _TeamDomain.GetTeamsByClubGuid(id);
        return Json(teams);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> InsertMembershipRequest(MembershipRequestViewModel viewModel)
    {
        ViewBag.Club = await _ClubDomain.GetClub();
        ViewBag.Team = await _TeamDomain.GetTeam();
        ViewBag.Student = await _StudentDomain.GetStudent();

        if (ModelState.IsValid)
        {
            try
            {
                int check = await _domain.InsertMembershipRequest(viewModel);
                if (check == 1)
                {
                    ViewBag.Successful = "تم رفع الطلب بنجاح";
                    return View(viewModel);
                }
                else
                    ViewBag.Error = "فشل في الإضافة";
            }
            catch
            {
                ViewData["Failed"] = "Failed";
            }
        }
        return View(viewModel);
    }

}
