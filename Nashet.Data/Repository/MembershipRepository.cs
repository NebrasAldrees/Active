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
    public class MembershipRepository : BaseRepository<tblMembership>
    {
        public MembershipRepository(NashetContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<IList<tblMembership>> GetAllMembers()
        {
            return await dbSet.Where(member => member.IsDeleted == false).ToListAsync(); 
        }
        public virtual async Task<tblMembership> GetMemberByIdAsync(int id)
        {
            return await dbSet.Where(member => member.IsDeleted == false && member.MembershipId == id)
                            .FirstOrDefaultAsync();
        }
        public virtual async Task<int> InsertMember(tblMembership Member)
        {
            try
            {

                await InsertAsync(Member);
                return 1;


            }
            catch 
            {
                return 0;
            }
        }
    }
}
