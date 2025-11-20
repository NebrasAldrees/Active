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
    private readonly ClubRepository _ClubRepository;
    private readonly TeamRepository _TeamRepository;
    private readonly StudentRepository _StudentRepository;


    public MembershipRequestDomain(MembershipRequestRepository repo, ClubRepository clubRepository, TeamRepository teamRepository, StudentRepository studentRepository)
    {
        _repo = repo;
        _ClubRepository = clubRepository;
        _TeamRepository = teamRepository;
        _StudentRepository = studentRepository;
    }
    public async Task<tblMembershipRequest> GetRequestByGuid(Guid guid)
    {
        var Request = await _repo.GetRequestByGUID(guid);

        if (Request == null)
        {
            throw new KeyNotFoundException($"طلب العضوية المطلوب غير متوفر");
        }
        return Request;
    }

    //public async Task<IList<MembershipRequestViewModel>> GetMembershipRequests()
    //{
    //    return _repo.GetAllRequests().Result.Select(m => new MembershipRequestViewModel
    //    {
    //        ClubID = (int)m.ClubID,
    //        RequestTeam1 = m.RequestTeam1.Value,
    //        RequestTeam2 = m.RequestTeam2,
    //        RequestTeam3 = m.RequestTeam3,
    //        RequestReason = m.RequestReason,
    //        RequestDate = m.RequestDate,
    //        StudentID = m.StatusId
    //        StatusId = m.StatusId,
    //        Guid = m.Guid,
    //        CreationDate = m.CreationDate
    //    }).ToList();
    //}

    public async Task<int> InsertMembershipRequest(MembershipRequestViewModel viewModel)
    {
        bool topicExists = await _repo.IsRequestExists(viewModel.ClubID);
        if (topicExists)
        {
            return -1;
        }
        var club = await _ClubRepository.GetClubByGuid(viewModel.ClubGuid);
        var team1 = await _TeamRepository.GetTeamByGuid(viewModel.RequestTeam1);
        var team2 = await _TeamRepository.GetTeamByGuid(viewModel.RequestTeam2);
        var team3 = await _TeamRepository.GetTeamByGuid(viewModel.RequestTeam3);


        var entity = new tblMembershipRequest
        {
            ClubID = club.ClubId,
            RequestTeam1 = team1.TeamId,
            RequestTeam2 = team2.TeamId,
            RequestTeam3 = team3.TeamId,
            RequestReason = viewModel.RequestReason,
            RequestDate = viewModel.RequestDate,
            StudentID = viewModel.StudentID
        };

        return await _repo.InsertMembershipRequest(entity);
    }


    public virtual async Task<int> DeleteRequest(Guid guid)
    {
        try
        {
            var Request = await _repo.GetRequestByGUID(guid);
            if (Request == null)
            {
                return 0; // Site not found
            }
            Request.IsDeleted = true;
            int check = await _repo.DeleteRequest(Request);
            if (check == null)
                return 0;
            else
                return 1;

        }
        catch
        {
            return 0;
        }
    }
}
