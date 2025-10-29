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

        //retrive the photo v  

        public AnnouncementRepository(NashetContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<IList<tblAnnouncement>> GetAllAnnouncement()
        {
            return await dbSet.Where(Announcement => Announcement.IsDeleted == false).ToListAsync();


        }
        public virtual async Task<tblAnnouncement> GetAnnouncementByGuid(Guid guid)
        {
            return await dbSet.Where(A => A.IsDeleted == false && A.Guid == guid)
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
                Console.WriteLine($"خطأ في الإضافة:{ex.Message}");
                return 0;
            }
        }

        public virtual async Task<bool> IsAnnouncementNameExists(string AnnouncementTopic, string AnnouncementType,
            Guid? excludeAnnouncementGuid = null)
        {
            var query = dbSet.Where(A => A.IsDeleted == false);

            if (excludeAnnouncementGuid.HasValue)
            {
                query = query.Where(A => A.Guid != excludeAnnouncementGuid.Value);
            }

            return await query.AnyAsync(a =>
                a.AnnouncementTopic == AnnouncementTopic ||
                a.AnnouncementType == AnnouncementType
            );
        }
        
        public virtual async Task<int> DeleteAnnouncement(tblAnnouncement Announcement)
        {
            try
            {
                IsDeleted(Announcement);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public virtual async Task<int> UpdateAnnouncement(tblAnnouncement Announcement)
        {
            try
            {
                await UpdateAsync(Announcement);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
