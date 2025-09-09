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
    public class ActivityRequestRepository : BaseRepository<tblActivityRequest>
    {

   
        public ActivityRequestRepository(NashetContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<IList<tblActivityRequest>> GetAllARequest()
        {
            return await dbSet.Where(AReq => AReq.IsDeleted == false).ToListAsync();


        }
    }
}
