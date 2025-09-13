using Microsoft.EntityFrameworkCore;
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
        public async Task<tblActivityRequest> GetActivityRequestById(int id)
        {
            var ActivityRequest = await _ActivityRequestRepository.GetActivityRequestById(id);

            if (ActivityRequest == null)
            {
                throw new KeyNotFoundException($"Activity Request requested with ID {id} was not found.");
            }

            return ActivityRequest;
        }
        public int DeleteActivityRequest(int id)
        {
            try
            {
                _ActivityRequestRepository.Delete(id);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

    }
}
