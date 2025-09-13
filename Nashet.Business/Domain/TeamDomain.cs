using Nashet.Business.Domain.Common;
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
    public class TeamDomain :BaseDomain
    {
        private readonly TeamRepository _TeamRepository;
        public TeamDomain(TeamRepository Repository)
        {
            _TeamRepository = Repository;
        }
        public async Task<IList<tblTeam>> GetTeam()
        {
            return await _TeamRepository.GetAllTeams();
        }
        public async Task<tblTeam> GetTeamById(int id)
        {
            var Team= await _TeamRepository.GetTeamByIdAsync(id);

            if (Team == null)
            {
                throw new KeyNotFoundException($"Team request with ID {id} was not found.");
            }

            return Team;
        }
        public virtual async Task<int> InsertTeam(tblTeam team)
        {
            try
            {
                await _TeamRepository.InsertTeam(team);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int DeleteTeam(int id)
        {
            try
            {
                _TeamRepository.Delete(id);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
