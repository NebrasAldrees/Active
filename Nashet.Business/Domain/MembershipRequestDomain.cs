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
    public class MembershipRequestDomain : BaseDomain
    {
        private readonly MembershipRequestRepository _MembershipRequestRepository;
        public MembershipRequestDomain(MembershipRequestRepository Repository)
        {
            _MembershipRequestRepository = Repository;
        }
        public async Task<IList<tblMembershipRequest>> GetMembershipRequest(int id)
        {
            return await _MembershipRequestRepository.GetAllMembershipRequest();
        }
        public async Task<tblMembershipRequest> GetMembershipRequestById(int id)
        {
            var membershipRequest = await _MembershipRequestRepository.GetMembershipRequestById(id);

            if (membershipRequest == null)
            {
                throw new KeyNotFoundException($"Membership request with ID {id} was not found.");
            }

            return membershipRequest;
        }
        public virtual async Task<int> InsertMembershipRequest(tblMembershipRequest MembershipRequest)
        {
            try
            {
                await _MembershipRequestRepository.InsertMembershipRequest(MembershipRequest);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int DeleteUser(int id)
        {
            try
            {
                _MembershipRequestRepository.Delete(id);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
