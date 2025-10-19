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
            return await dbSet.Where(Activity => Activity.IsDeleted == false).ToListAsync(); 
        }

        public virtual async Task<tblActivity> GetActivityByGuid(Guid guid)
        {
            return await dbSet.Where(Activity => Activity.IsDeleted == false && Activity.Guid == guid)
            .FirstOrDefaultAsync();
        }

        public virtual async Task<int> InsertActivity(tblActivity activity)
        {
            try
            {
                await InsertAsync(activity);
                return 1;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error inserting system:{ex.Message}");
                return 0;
            }
        }

        public virtual async Task<int> updateActivity(tblActivity activity)
        {
            try
            {
                await UpdateAsync(activity);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public virtual async Task<int> DeleteActivity(tblActivity activity)
        {
            try
            {
                if (activity == null || activity.IsDeleted == true)
                {
                    return 0;
                }

                IsDeleted(activity);
                return 1;
            }
            catch
            {
                return 0;
            }
        }


    }
}
