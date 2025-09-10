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
    public class RequestDomain : BaseDomain
    {
        private readonly RequestRepository _RequestRepository;
        public RequestDomain(RequestRepository Repository)
        {
            _RequestRepository = Repository;
        }
        public async Task<IList<tblRequest>> GetRequest()
        {
            return await _RequestRepository.GetAllRequests();
        }
        public virtual async Task<int> InsertRequest(tblRequest Request)
        {
            try
            {
                await _RequestRepository.InsertRequest(Request);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
