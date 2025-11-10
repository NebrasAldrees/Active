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
    public class TeamDomain : BaseDomain
    {
        private readonly TeamRepository _TeamRepository;
        private readonly ClubRepository _ClubRepository;
        public TeamDomain(TeamRepository TeamRepository, ClubRepository ClubRepository)
        {
            _TeamRepository = TeamRepository;
            _ClubRepository = ClubRepository;
        }
        public async Task<IList<TeamViewModel>> GetTeam()
        {
            return _TeamRepository.GetAllTeams().Result.Select(t => new TeamViewModel
            {
                TeamId = t.TeamId,
                ClubId = (int)t.ClubId,
                TeamNameAR = t.TeamNameAR,
                TeamNameEn = t.TeamNameEn,
                Guid = t.Guid
            }).ToList();
        }

        public async Task<List<TeamViewModel>> GetTeamsByClubGuid(Guid clubGuid)
        {
            var teams = await _TeamRepository.GetTeamByClubGuid(clubGuid);
            return teams.Select(t => new TeamViewModel
            {
                Guid = t.Guid,
                TeamNameAR = t.TeamNameAR
            }).ToList();
        }


        public async Task<int> InsertTeam(TeamViewModel viewModel)
        {
            try
            {
                var club = await _ClubRepository.GetClubByGuid(viewModel.ClubGuid);
                if (club == null) throw new Exception("النادي غير موجود");
                tblTeam team = new tblTeam
                {
                    ClubId = club.ClubId,
                    TeamNameAR = viewModel.TeamNameAR,
                    TeamNameEn = viewModel.TeamNameEn
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

        public virtual async Task<int> DeleteTeam(Guid Guid)
        {
            try
            {
                var team = await _TeamRepository.GetTeamByGuid(Guid);
                if (team == null)
                {
                    return 0;
                }
                team.IsDeleted = true;
                int check = await _TeamRepository.DeleteTeam(team);
                if (check <= 0)
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
}
