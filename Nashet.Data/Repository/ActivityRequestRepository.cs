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

        public virtual async Task<IList<tblActivityRequest>> GetAllRequests()
        {
            return await dbSet.Where(AReq => AReq.IsDeleted == false).ToListAsync();
        }

        public virtual async Task<tblActivityRequest> GetActivityRequestById(int id)
        {
            return await dbSet.Where(ActivityRequest => ActivityRequest.IsDeleted == false && ActivityRequest.ActivityRequestId == id)
            .FirstOrDefaultAsync();
        }

        public virtual async Task<int> InsertActivityRequest(tblActivityRequest activityRequest)
        {
            try
            {
                await InsertAsync(activityRequest);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
