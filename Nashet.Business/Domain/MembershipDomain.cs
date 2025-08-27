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
    public class MembershipDomain :BaseDomain
    {
        private readonly MembershipRepository _MembershipRepository;
        public MembershipDomain(MembershipRepository Repository)
        {
            _MembershipRepository = Repository;
        }
        public async Task<IList<tblMembership>> GetMember()
        {
            return await _MembershipRepository.GetAllMembers();
        }
    }
}
