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
    public class PositionRequestDomain : BaseDomain
    {
        private readonly PositionRequestRepository _PositionRequestRepository;
        public PositionRequestDomain(PositionRequestRepository Repository)
        {
            _PositionRequestRepository = Repository;
        }
        public async Task<IList<tblPositionRequest>> GetPositionRequest()
        {
            return await _PositionRequestRepository.GetAllPositionRequest();
        }

        public async Task<tblPositionRequest> GetPositionRequestByIdAsync(int id)
        {
            var PositionRequest = await _PositionRequestRepository.GetPositionRequestByIdAsync(id);

            if (PositionRequest == null)
            {
                throw new KeyNotFoundException($"Position request with ID {id} was not found.");
            }

            return PositionRequest;
        }
        public virtual async Task<int> InsertPositionRequest(tblPositionRequest PositionRequest)
        {
            try
            {
                await _PositionRequestRepository.InsertPositionRequest(PositionRequest);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
