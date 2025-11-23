using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;
using Nashet.Data.Repository;
using System;
using System.Linq;
using System.Security.Policy;
using static System.Reflection.Metadata.BlobBuilder;

namespace Nashet.Areas.ClubSupervisor.Controllers
{

    [Area("ClubSupervisor")]
    [Authorize(Roles = "ClubSupervisor")]
    public class MembershipController : Controller
    {
        private readonly MembershipDomain _MembershipDomain;
        private readonly TeamDomain _TeamDomain;
        private readonly StudentDomain _StudentDomain;
        private readonly UserDomain _UserDomain;
        private readonly ClubRoleDomain _ClubRoleDomain;
        private readonly StatusDomain _StatusDomain;
        private readonly MembershipRequestDomain _MembershipRequestDomain;
        private readonly ClubDomain _ClubDomain;
        public MembershipController(MembershipDomain MembershipDomain, TeamDomain teamDomain, StudentDomain studentDomain,
            ClubRoleDomain clubRoleDomain, StatusDomain statusDomain, MembershipRequestDomain membershipRequestDomain,
            ClubDomain clubDomain, UserDomain userDomain)
        {
            _MembershipDomain = MembershipDomain;
            _TeamDomain = teamDomain;
            _StudentDomain = studentDomain;
            _ClubRoleDomain = clubRoleDomain;
            _StatusDomain = statusDomain;
            _MembershipRequestDomain = membershipRequestDomain;
            _ClubDomain = clubDomain;
            _UserDomain = userDomain;
        }
        public async Task<IActionResult> ViewMember()
        {
            var members = await _MembershipDomain.GetMembership();
            var teams = await _TeamDomain.GetTeam();
            var students = await _StudentDomain.GetStudent();
            var roles = await _ClubRoleDomain.GetClubRole();

            var enrichedMembers = new List<MembershipViewModel>();

            foreach (var req in members)
            {

                var student = students.FirstOrDefault(s => s.StudentId == req.StudentId);
                var clubRole = roles.FirstOrDefault(s => s.ClubRoleId == req.ClubRoleId);
                var team = teams.FirstOrDefault(t => t.TeamId == req.TeamId);

                enrichedMembers.Add(new MembershipViewModel
                {
                    Guid = req.Guid,
                    MembershipId = req.MembershipId,
                    JoinDate = req.JoinDate,
                    StudentNameAr = student?.StudentNameAr ?? "—",
                    ClubRoleType = clubRole?.RoleTypeAr ?? "—",
                    TeamNameAr = team?.TeamNameAR ?? "—",

                });
            }

            return View(enrichedMembers);
        }
        public async Task<IActionResult> InsertMember()
        {
            await LoadTeamAndRole();
            return View(new MembershipViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SearchStudent(string academicId)
        {
            var student = await _StudentDomain.GetByAcademicId(academicId);
            var viewModel = new MembershipViewModel { AcademicId = academicId };

            if (student == null)
            {
                ViewData["Error"] = "لم يتم العثور على الطالب";
            }
            else
            {
                viewModel.StudentId = student.StudentId;
                viewModel.StudentNameAr = student.StudentNameAr;
                viewModel.Student = student;
            }

            await LoadTeamAndRole();
            return View("InsertMember", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertMember(MembershipViewModel viewModel)
        {
            await LoadTeamAndRole();

            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _MembershipDomain.InsertMembership(viewModel);
                    if (check == 1)
                    {
                        TempData["Success"] = "تم اضافة عضو في النادي بنجاح";
                        return RedirectToAction("InsertMember");
                    }
                    else
                    {
                        TempData["Failed"] = "فشل في الإضافة";
                    }
                }
                catch
                {
                    TempData["Failed"] = "فشل في عملية الإضافة";
                }
            }

            return View(viewModel);
        }

        private async Task LoadTeamAndRole()
        {
            var username = User.Identity?.Name;
            var user = await _UserDomain.GetUserByUsername(username);

            if (user?.ClubId != null)
            {
                var club = await _ClubDomain.GetClubById(user.ClubId.Value);
                if (club != null)
                {
                    ViewBag.Team = await _TeamDomain.GetTeamsByClubGuid(club.Guid);
                }
            }

            ViewBag.ClubRole = await _ClubRoleDomain.GetClubRole();
        }


        public async Task<IActionResult> UpdateMembership(Guid Guid)
        {
            try
            {
                var membership = await _MembershipDomain.GetMembersByGuid(Guid);
                if (membership == null)
                {
                    ViewData["Error"] = "العضوية غير موجودة";
                    return RedirectToAction(nameof(ViewMember));
                }

                await LoadTeamAndRole();
                var team = await _TeamDomain.GetTeamById(membership.TeamId);
                var role = await _ClubRoleDomain.GetClubRoleById(membership.ClubRoleId);
                var student = await _StudentDomain.GetStudentById(membership.StudentId);
                if (student == null)
                {
                    TempData["Error"] = "تعذر العثور على بيانات الطالب";
                    return RedirectToAction("AccessDenied", "Home");
                }
                ViewBag.StudentNameAr = student.StudentNameAr;
                ViewBag.AcademicId = student.AcademicId;
                ViewBag.studentId = student.StudentId;

                var viewModel = new MembershipViewModel
                {
                    Guid = membership.Guid,
                    MembershipId = membership.MembershipId,
                    ClubRoleGuid = role.Guid,
                    AcademicId = student.AcademicId,
                    TeamGuid = team.Guid,
                };
                ViewData["Successful"] = "تم التحديث بنجاح";
                return View(viewModel);
            }
            catch
            {
                ViewData["Failed"] = "فشل في التحديث";
                return RedirectToAction(nameof(UpdateMembership));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateMembership(MembershipViewModel viewModel)
        {
            await LoadTeamAndRole();

            var student = await _StudentDomain.GetStudentById(viewModel.StudentId);
            if (student == null)
            {
                TempData["Error"] = "تعذر العثور على بيانات الطالب";
                return RedirectToAction("AccessDenied", "Home");
            }

            ViewBag.StudentNameAr = student.StudentNameAr;
            ViewBag.AcademicId = student.AcademicId;
            ViewBag.studentId = student.StudentId;

            if (ModelState.IsValid)
            {
                try
                {
                    
                    int check = await _MembershipDomain.UpdateMembership(viewModel);
                    if (check == 1)
                    {
                        return Json(new { Success = true, message = "تم تعديل بيانات العضوية بنجاح" });
                    }
                    else
                        return Json(new { Success = false, message = "فشل التحديث" });
                }
                catch (Exception ex)
                {
                    return Json(new { Success = false, message = "حدث خطأ أثناء التحديث: " + ex.Message });
                }
            }
            return View(viewModel);
        }


        public async Task<IActionResult> ViewMembershipRequests()
        {
            
            var username = User.Identity?.Name;
            var user = await _UserDomain.GetUserByUsername(username);

            if (user == null || user.ClubId == null)
            {
                TempData["Error"] = "لا يمكنك الوصول إلى هذه الصفحة بدون الانتماء إلى نادي";
                return RedirectToAction("AccessDenied", "Home");
            }

            
            var requests = await _MembershipRequestDomain.GetMembershipRequests();
            var students = await _StudentDomain.GetStudent();
            var statuses = await _StatusDomain.GetStatus();
            var clubs = await _ClubDomain.GetClub();
            var teams = await _TeamDomain.GetTeam();

            var enrichedRequests = new List<MembershipRequestViewModel>();

            
            foreach (var req in requests.Where(r => r.ClubID == user.ClubId))
            {
                var student = students.FirstOrDefault(s => s.AcademicId == req.AcademicId);
                var status = statuses.FirstOrDefault(s => s.StatusId == req.StatusId);
                var club = clubs.FirstOrDefault(c => c.ClubId == req.ClubID);
                var team1 = teams.FirstOrDefault(t => t.Guid == req.RequestTeam1);
                var team2 = teams.FirstOrDefault(t => t.Guid == req.RequestTeam2);
                var team3 = teams.FirstOrDefault(t => t.Guid == req.RequestTeam3);

                enrichedRequests.Add(new MembershipRequestViewModel
                {
                    Guid = req.Guid,
                    MRId = req.MRId,
                    StatusTypeAr = status?.StatusTypeAr,
                    AcademicId = req.AcademicId,
                    StudentNameAr = student?.StudentNameAr,
                    ClubNameAR = club?.ClubNameAR,
                    TeamName1 = team1?.TeamNameAR,
                    TeamName2 = team2?.TeamNameAR,
                    TeamName3 = team3?.TeamNameAR,
                    RequestReason = req.RequestReason,
                    CreationDate = req.CreationDate,
                });
            }

            return View(enrichedRequests);
        }

        [HttpGet]
        public async Task<IActionResult> MembershipRequestDetails(Guid guid)
        {
            var request = await _MembershipRequestDomain.GetRequestByGuid(guid);
            if (request == null)
            {
                TempData["Error"] = "تعذر العثور على بيانات الطلب";
                return RedirectToAction("ViewMembershipRequests");
            }

            var student = await _StudentDomain.GetByAcademicId(request.AcademicId);
            var status = await _StatusDomain.GetStatusById(request.StatusId); 
            var team1 = await _TeamDomain.GetTeamByGuid(request.RequestTeam1); 
            var team2 = await _TeamDomain.GetTeamByGuid(request.RequestTeam2); 
            var team3 = await _TeamDomain.GetTeamByGuid(request.RequestTeam3);

            ViewBag.ClubRole = await _ClubRoleDomain.GetClubRole();

            var viewModel = new MembershipRequestViewModel
            {
                Guid = request.Guid,
                StudentNameAr = student?.StudentNameAr,
                StudentSkills = student?.StudentSkills,
                StatusTypeAr = status?.StatusTypeAr,
                TeamName1 = team1?.TeamNameAR,
                TeamName2 = team2?.TeamNameAR,
                TeamName3 = team3?.TeamNameAR,
                RequestReason = request.RequestReason,
                CreationDate = request.CreationDate,
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptRequest(MembershipRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "البيانات غير مكتملة";
                return RedirectToAction("ViewMembershipRequests");
            }

            var request = await _MembershipRequestDomain.GetRequestByGuid(model.Guid);
            if (request == null)
            {
                TempData["Error"] = "تعذر العثور على بيانات الطلب";
                return RedirectToAction("ViewMembershipRequests");
            }

            var accepted = await _MembershipRequestDomain.AcceptMembershipRequest(request.Guid);
            if (!accepted)
            {
                return Json(new { error = false, message = "فشل في قبول الطلب" });
            }

            var team = await _TeamDomain.GetTeamByGuid(model.TeamGuid);
            var student = await _StudentDomain.GetByAcademicId(request.AcademicId);
            var clubRole = await _ClubRoleDomain.GetClubRoleByGuid(model.ClubRoleGuid);

            if (team == null || student == null || clubRole == null)
            {
                return Json(new { error = false, message = "فشل في جلب البيانات " });
            }

            var membership = new MembershipViewModel
            {
                StudentId = student.StudentId,
                TeamId = team.TeamId,
                ClubRoleId = clubRole.ClubRoleId
            };

            var inserted = await _MembershipDomain.InsertMembership(membership);
            if (inserted == 1)
            {
                TempData["success"] = "تم قبول الطلب وإنشاء عضوية للطالب بنجاح";
                return RedirectToAction("ViewMembershipRequests");
            }
            else
            {
                TempData["Error"] = "تم قبول الطلب ولكن فشل إنشاء العضوية" ;
            }
            return RedirectToAction("ViewMembershipRequests");
        }

        [HttpPost]
        public async Task<IActionResult> RejectRequest(Guid guid)
        {
            try
            {
                var result = await _MembershipRequestDomain.DeleteRequest(guid);

                if (result)
                {
                    return Json(new { Success = true, message = "تم رفض الطلب بنجاح" });
                }
                else
                {
                    return Json(new { Success = false, message = "فشل في رفض الطلب" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, message = "حدث خطأ أثناء الرفض: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMember(Guid guid)
        {
            try
            {
                bool deleted = await _MembershipDomain.DeleteMembership(guid);
                if (deleted)
                {
                    return Json(new { Success = true, message = "تم إلغاء العضوية بنجاح" });
                }
                else
                {
                    return Json(new { Success = false, message = "لم يتم العثور على العضوية أو فشل الحذف" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, message = "حدث خطأ أثناء الحذف: " + ex.Message });
            }
        }
    }
}


