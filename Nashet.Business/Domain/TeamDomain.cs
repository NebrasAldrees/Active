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
                Guid = t.Guid
            }).ToList();
        }

        public async Task<tblTeam> GetTeamById(int id)
        {
            var Team = await _TeamRepository.GetTeamByIdAsync(id);

            if (Team == null)
            {
                throw new KeyNotFoundException($"Team request with ID {id} was not found.");
            }

            return Team;
        }


        public async Task<int> InsertTeam(TeamViewModel viewModel)
        {
            try
            {
                tblTeam team = new tblTeam
                {
                    ClubId = viewModel.ClubId,
                    TeamNameAR = viewModel.TeamNameAR,
                    TeamNameEn = viewModel.TeamNameEn
                };
                int check = await _TeamRepository.InsertTeam(team);
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
                        Table = "tblTeam",
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
        
        public virtual async Task<int> DeleteTeam(int Id)
        {
            try
            {
                var team = await _TeamRepository.GetTeamByIdAsync(Id);
                if (team == null)
                {
                    return 0; // Site not found
                }

                int check = await _TeamRepository.DeleteTeam(team);
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
}
