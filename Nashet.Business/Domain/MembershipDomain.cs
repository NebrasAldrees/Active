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
    public class MembershipDomain : BaseDomain
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
        public async Task<tblMembership> GetMemberByIdAsync(int id)
        {
            var Member = await _MembershipRepository.GetMemberByIdAsync(id);

            if (Member == null)
            {
                throw new KeyNotFoundException($"Membership request with ID {id} was not found.");
            }

            return Member;
        }
        public virtual async Task<int> InsertMember(tblMembership Member)
        {
            try
            {
                await _MembershipRepository.InsertMember(Member);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int DeleteMember(int id)
        {
            try
            {
                _MembershipRepository.Delete(id);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
