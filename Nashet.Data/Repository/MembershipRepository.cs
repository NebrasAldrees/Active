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
    public class MembershipRepository : BaseRepository<tblStudent>
    {
        public MembershipRepository(NashetContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<IList<tblMembership>> GetAllMembers()
        {
            return await dbSet.Where(m => m.IsDeleted == false).ToListAsync(); // m for member
        }
        public virtual async Task<int> InsertMember(tblMembership Member)
        {
            try
            {

            }
        }
    }
}
