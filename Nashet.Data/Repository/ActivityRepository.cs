using Microsoft.EntityFrameworkCore;
using Nashet.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Repository
{
    public class ActivityRepository
    {
        public ActivityRepository(NashetContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<IList<tblActivity>> GetAllActivities()
        {
            return await dbSet.Where(a => a.IsDeleted == false).ToListAsync(); //a for activity
        }

        public virtual async Task<int> InsertActivity(tblActivity activity)
        {
            try
            {
                await dbSet.AddAsync(activity);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        

    }
}
