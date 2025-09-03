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
    }
}
