using Microsoft.EntityFrameworkCore;
using Nashet.Data.Models;
using Nashet.Data.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Repository
{
    public class MembershipRequestRepository : BaseRepository<tblMembershipRequest>
    {
        public MembershipRequestRepository(NashetContext dbContext) : base(dbContext)
        {
        }
        public virtual async Task<IList<tblMembershipRequest>> GetAllMembershipRequest(int id)
        {
            return await dbSet.Where(MembershipRequest => MembershipRequest.IsDeleted == false && MembershipRequest.ClubID == id).ToListAsync();
        }

        public virtual async Task<IList<tblMembershipRequest>> GetAllMembershipRequest()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<tblMembershipRequest> GetMembershipRequestById(int id)
        {
            return await dbSet.Where(MembershipRequest => MembershipRequest.IsDeleted == false && MembershipRequest.MRId == id)
                .FirstOrDefaultAsync();
        }
        public virtual async Task<int> InsertMembershipRequest(tblMembershipRequest MembershipRequest)
        {
            try
            {
                await InsertAsync(MembershipRequest);
                return 1;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error inserting system:{ex.Message}");
                return 0;
            }
        }
    }
}
//nn