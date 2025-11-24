using Nashet.Business.Domain.Common;
using Nashet.Business.ViewModels;
using Nashet.Data.Models;
using Nashet.Data.Repository;
using Nashet.Data.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MembershipRequestDomain : BaseDomain
{
    private readonly MembershipRequestRepository _repo;
    private readonly MembershipRepository _MembershipRepository;
    private readonly ClubRepository _ClubRepository;
    private readonly ClubRoleRepository _ClubRoleRepository;
    private readonly TeamRepository _TeamRepository;
    private readonly StudentRepository _StudentRepository;


    public MembershipRequestDomain(MembershipRequestRepository repo, ClubRepository clubRepository,
        TeamRepository teamRepository, StudentRepository studentRepository, MembershipRepository membershipRepository,
        ClubRoleRepository clubRoleRepository)
    {
        _repo = repo;
        _ClubRepository = clubRepository;
        _TeamRepository = teamRepository;
        _StudentRepository = studentRepository;
        _MembershipRepository = membershipRepository;
        _ClubRoleRepository = clubRoleRepository;
    }
    public async Task<MembershipRequestViewModel> GetRequestByGuid(Guid guid)
    {
        var request = await _repo.GetRequestByGUID(guid);
        if (request == null)
        {
            throw new KeyNotFoundException("طلب العضوية المطلوب غير متوفر");
        }

        return new MembershipRequestViewModel
        {
            ClubID = (int)request.ClubID,
            RequestTeam1 = (Guid)request.RequestTeam1,
            RequestTeam2 = (Guid)request.RequestTeam2,
            RequestTeam3 = (Guid)request.RequestTeam3,
            RequestReason = request.RequestReason,
            CreationDate = request.CreationDate,
            StudentID = request.StudentID,
            StatusId = request.StatusId,
            Guid = request.Guid,
            Student = request.Student,

        };


    }

    public async Task<IList<MembershipRequestViewModel>> GetMembershipRequests()
    {
        return _repo.GetAllRequests().Result.Select(m => new MembershipRequestViewModel
        {
            ClubID = (int)m.ClubID,
            RequestTeam1 = (Guid)m.RequestTeam1,
            RequestTeam2 = (Guid)m.RequestTeam2,
            RequestTeam3 = (Guid)m.RequestTeam3,
            RequestReason = m.RequestReason,
            CreationDate = m.CreationDate,
            StudentID = m.StudentID,
            StatusId = m.StatusId,
            Guid = m.Guid,
            Student = m.Student,
        }).ToList();
    }

    public async Task<int> InsertMembershipRequest(MembershipRequestViewModel viewModel)
    {
        bool topicExists = await _repo.IsRequestExists(viewModel.ClubID);
        if (topicExists)
        {
            return -1;
        }
        var club = await _ClubRepository.GetClubByGuid(viewModel.ClubGuid);
        var student = await _StudentRepository.GetByAcademicIdAsync(viewModel.AcademicId);
        var team1 = await _TeamRepository.GetTeamByGuid(viewModel.RequestTeam1);
        var team2 = await _TeamRepository.GetTeamByGuid(viewModel.RequestTeam2);
        var team3 = await _TeamRepository.GetTeamByGuid(viewModel.RequestTeam3);


        var entity = new tblMembershipRequest
        {
            ClubID = club.ClubId,
            RequestTeam1 = team1.Guid,
            RequestTeam2 = team2.Guid,
            RequestTeam3 = team3.Guid,
            RequestReason = viewModel.RequestReason,
            StudentID = student.StudentId,
            StatusId = 1
        };

        return await _repo.InsertMembershipRequest(entity);
    }

    public virtual async Task<bool> AcceptMembershipRequest(MembershipRequestViewModel viewModel)
    {
        try
        {
            if (viewModel == null || viewModel.Guid == Guid.Empty)
                return false;

            // Fetch the full request from the database
            var request = await _repo.GetRequestByGUID(viewModel.Guid);
            if (request == null)
                return false;

            // Update status
            request.IsActive = false;
            request.StatusId = 2;

            var team = await _TeamRepository.GetTeamByGuid(viewModel.TeamGuid);
            var role = await _ClubRoleRepository.GetClubRoleByGuid(viewModel.ClubRoleGuid);

            // Create membership entity using full request data
            var entity = new tblMembership
            {
                StudentId = request.StudentID, // from the fetched request
                ClubRoleId = role.ClubRoleId,
                TeamId = team.TeamId
            };

            // Save changes
            await _repo.AcceptRequest(request); // updates the request
            await _MembershipRepository.InsertAsync(entity); // inserts the membership

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteRequest(Guid guid)
    {
        try
        {
            var request = await _repo.GetRequestByGUID(guid);
            if (request == null)
                return false;

            request.IsDeleted = true;
            request.StatusId = 3;
            await _repo.DeleteRequest(request);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
