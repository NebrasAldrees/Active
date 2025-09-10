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
    public class EmailNotificationRepository : BaseRepository<tblEmailNotificationLog>
    {
        public EmailNotificationRepository(NashetContext dbContext):base(dbContext)
        { }
        
        //public virtual async Task<IList<tblEmailNotificationLog>>GetAllEmailNotifications()
        //{
        //    return await dbSet.Where(email => email.IsDeleted == false).ToListAsync(); // email as email notification
        //}
        public virtual async Task<int> InsertEmailNotification(tblEmailNotificationLog emailNotification)
        {
            try
            {
                await dbSet.AddAsync(emailNotification);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

    }
}
