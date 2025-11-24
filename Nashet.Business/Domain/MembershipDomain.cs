using Azure.Core;
using Nashet.Business.Domain.Common;
using Nashet.Business.ViewModels;
using Nashet.Data.Models;
using Nashet.Data.Repository;
using Nashet.Data.Repository.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.Domain
{
    public class MembershipDomain : BaseDomain
    {
        private readonly MembershipRepository _MembershipRepository;
        private readonly TeamRepository _TeamRepository;
        private readonly StudentRepository _StudentRepository;
        private readonly ClubRoleRepository _ClubRoleRepository;
        public MembershipDomain(MembershipRepository membershipRepository, TeamRepository teamRepository, StudentRepository studentRepository, ClubRoleRepository clubRoleRepository)
        {
            _MembershipRepository = membershipRepository;
            _TeamRepository = teamRepository;
            _StudentRepository = studentRepository;
            _ClubRoleRepository = clubRoleRepository;
        }

        public async Task<IList<MembershipViewModel>> GetMembership()
        {
            return _MembershipRepository.GetAllMembers().Result.Select(m => new MembershipViewModel
            {
                Guid = m.Guid,
                StudentId = (int)m.StudentId,
                Student = m.Student,
                ClubRoleId = (int)m.ClubRoleId,
                ClubRole = m.ClubRole,
                TeamId = (int)m.TeamId,
                Team = m.Team,
                JoinDate = m.JoinDate,
                

            }).ToList();
        }

        public async Task<List<MembershipViewModel>> GetMembersByClubGuid(Guid clubGuid)
        {
            var members = await _MembershipRepository.GetMembersByClubGuid(clubGuid);
            return members.Select(t => new MembershipViewModel
            {
                Guid = t.Guid,
                StudentId = t.StudentId,
                Student = t.Student,


            }).ToList();
        }
        public async Task<tblMembership> GetMembersByGuid(Guid Guid)
        {
            var member = await _MembershipRepository.GetMemberByGuid(Guid);
            if (member == null)
            {
                throw new KeyNotFoundException($"العضو المطلوب غير متوفر");
            }

            return member;
        }

        public virtual async Task<tblMembership> GetStudentMembershipAsync(string academicId)
        {
            try
            {
                return await _MembershipRepository.GetStudentMembershipAsync(academicId);
            }
            catch
            {
                return null;
            }
        }

        public async Task<int> InsertMembership(MembershipViewModel viewModel)
        {
            try
            {
                var team = await _TeamRepository.GetTeamByGuid(viewModel.TeamGuid);
                var clubRole = await _ClubRoleRepository.GetClubRoleByGuid(viewModel.ClubRoleGuid);
                var student = await _StudentRepository.GetByAcademicIdAsync(viewModel.AcademicId);
                tblMembership membership = new tblMembership
                {
                    StudentId = student.StudentId,
                    ClubRoleId = clubRole.ClubRoleId,
                    TeamId = team.TeamId,
                };
                int check = await _MembershipRepository.InsertMember(membership);
                if (check == 0)
                {
                    return 0;
                }
                else
                {
                    var systemLog = new tblSystemLogs
                    {
                        UserId = 23456,
                        username = "najd",
                        RecordId = 17,
                        Table = "tblMembership",
                        operation_date = DateTime.Now,
                        operation_type = "Insert",
                        OldValue = null,
                        // NewValue=
                    };
                    //await _SystemLogsRepository.InsertLog(systemLog);
                    return 1;
                }
               
            }
            catch
            {
                return 0;
            }
        }


        public virtual async Task<int> UpdateMembership(MembershipViewModel viewModel)
        {
            try
            {
                var Membership = await _MembershipRepository.GetMemberByGuid(viewModel.Guid);
                if (Membership == null)
                {
                    return 0;
                }
                var team = await _TeamRepository.GetTeamByGuid(viewModel.TeamGuid);
                var student = await _StudentRepository.GetByAcademicIdAsync(viewModel.AcademicId);
                var role = await _ClubRoleRepository.GetClubRoleByGuid(viewModel.ClubRoleGuid);
                Membership.TeamId = team.TeamId;
                Membership.StudentId = student.StudentId;
                Membership.ClubRoleId = role.ClubRoleId;
                

                int check = await _MembershipRepository.updateMember(Membership);
                if (check == 0)
                    return 0;
                else
                    return 1;
            }
            catch
            {
                return 0;
            }

        }

        public async Task<bool> DeleteMembership(Guid guid)
        {
            try
            {
                var member = await _MembershipRepository.GetMemberByGuid(guid);
                if (member == null)
                    return false;

                member.IsDeleted = true;
                await _MembershipRepository.UpdateAsync(member);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

            
        }
    }
}
