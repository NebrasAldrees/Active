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
    public class Request_typeRepository : BaseRepository<tblRequest_type>
    {
        public Request_typeRepository(NashetContext context) : base(context)
        {
        }

        public virtual async Task<tblRequest_type> GetMembershipRequestById(int id)
        {
            return await dbSet.Where(Request_type => Request_type.IsDeleted == false && Request_type.TypeId == id)
                .FirstOrDefaultAsync();
        }

    }
}
