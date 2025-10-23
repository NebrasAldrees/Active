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
    public class AnnouncementRepository : BaseRepository<tblAnnouncement>
    {
        public AnnouncementRepository(NashetContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<IList<tblAnnouncement>> GetAllAnnouncement()
        {
            return await dbSet.Where(Announcement => Announcement.IsDeleted == false).ToListAsync();


        }
        public virtual async Task<tblAnnouncement> GetAnnouncementByIdAsync(int id)
        {
            return await dbSet.Where(Announcement => Announcement.IsDeleted == false && Announcement.AnnouncementId== id)
                            .FirstOrDefaultAsync();
        }
        public virtual async Task<int> InsertAnnouncement(tblAnnouncement Announcement)
        {
            try
            {
                await InsertAsync(Announcement);
                return 1;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error inserting system:{ex.Message}");
                return 0;
            }
        }
    }
}
