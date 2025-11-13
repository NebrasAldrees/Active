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
            return await dbSet.Where(Activity => Activity.IsActive == true && Activity.IsDeleted == false).ToListAsync();
        }

        public virtual async Task<tblActivity> GetActivityByGUID(Guid? guid)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(Activity => Activity.IsDeleted == false && Activity.Guid == guid);
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
                Console.WriteLine($"خطأ في الإضافة:{ex.Message}");
                return 0;
            }
        }

        public virtual async Task<bool> IsActivityTopicExists(string ActivityTopic, Guid? excludeActivityGuid = null)
        {
            var query = dbSet.Where(activity => activity.IsDeleted == false);

            if (excludeActivityGuid.HasValue)
            {
                query = query.Where(activity => activity.Guid != excludeActivityGuid.Value);
            }

            return await query.AnyAsync(activity => activity.ActivityTopic == ActivityTopic);
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
                await UpdateAsync(activity);
                return 1;
            }
            catch
            {
                return 0;
            }
        }



    }
}
