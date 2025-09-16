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

namespace Nashet.Business.Domain
{
    public class TeamDomain(TeamRepository Repository) : BaseDomain
    {
        private readonly TeamRepository _TeamRepository = Repository;
        public async Task<IList<TeamViewModel>> GetTeam()
        {
            return _TeamRepository.GetAllTeams().Result.Select(t => new TeamViewModel
            {
                TeamId = t.TeamId,
                ClubId = t.ClubId,
                TeamNameAR = t.TeamNameAR,
                TeamNameEn = t.TeamNameEn,
                Guid = t.Guid,

            }).ToList();
        }

        //public async Task<tblTeam> GetTeamById(int id)
        //{
        //    var Team= await _TeamRepository.GetTeamByIdAsync(id);

        //    if (Team == null)
        //    {
        //        throw new KeyNotFoundException($"Team request with ID {id} was not found.");
        //    }

        //    return Team;
        //}
        public async Task<int> InsertTeam(TeamViewModel viewModel)
        {
            try
            {
                tblTeam team = new tblTeam
                {
                    ClubId = viewModel.ClubId,
                    TeamNameAR = viewModel.TeamNameAR,
                    TeamNameEn = viewModel.TeamNameEn,
                    Guid = viewModel.Guid
                };
                int check = await _TeamRepository.InsertTeam(team);
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
        //public int DeleteTeam(int id)
        //{
        //    try
        //    {
        //        _TeamRepository.Delete(id);
        //        return 1;
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}
    }
}
