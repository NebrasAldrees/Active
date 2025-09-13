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
    public class ActivityRepository: BaseRepository<tblActivity>
    {
        public ActivityRepository(NashetContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<IList<tblActivity>> GetAllActivities()
        {
            return await dbSet.Where(Activity => Activity.IsDeleted == false).ToListAsync(); //a for activity
        }

        public virtual async Task<tblActivity> GetActivityById(int id)
        {
            return await dbSet.Where(Activity => Activity.IsDeleted == false && Activity.ActivityId == id)
            .FirstOrDefaultAsync();
        }

        public virtual async Task<int> InsertActivity(tblActivity activity)
        {
            try
            {
                await InsertAsync(activity);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        

    }
}
