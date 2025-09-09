using Nashet.Business.Domain.Common;
using Nashet.Data.Models;
using Nashet.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.Domain
{
    public class ActivityRequestDomain(ActivityRequestRepository Repository) : BaseDomain
    {
        private readonly ActivityRequestRepository _ActivityRequestRepository = Repository;

        public async Task<IList<tblActivityRequest>> GetActivityRequest()
        {
            return await _ActivityRequestRepository.GetAllRequests();
        }
    }
}
