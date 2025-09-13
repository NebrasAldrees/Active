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
    public class SystemNotificationRepository : BaseRepository<tblSystemNotification>
    {
        public SystemNotificationRepository(NashetContext dbContext) : base(dbContext)
        { }

        public virtual async Task<IList<tblSystemNotification>> GetAllNotifications()
        {
            return await dbSet.Where(Notification => Notification.IsDeleted == false).ToListAsync();
        }

        public virtual async Task<tblSystemNotification> GetNotificationByIdAsync(int id)
        {
            return await dbSet.Where(Notification => Notification.IsDeleted == false && Notification.SystemNotificationId == id)
                            .FirstOrDefaultAsync();
        }

        public virtual async Task<int> InsertNotification(tblSystemNotification Notification)
        {
            try
            {
                await InsertAsync(Notification);
                return 1;
            }
            catch
            {
                return 0;
            }


        }
    }
}
