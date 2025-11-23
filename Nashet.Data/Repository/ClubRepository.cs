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
    public class ClubRepository : BaseRepository<tblClub>
    {
        public ClubRepository(NashetContext dbContext) : base(dbContext)
        {
        }
        public virtual async Task<IList<tblClub>> GetAllClubs()
        {
            return await dbSet.Where(m => m.IsActive == true && m.IsDeleted == false).ToListAsync();
        }
        public virtual async Task<tblClub> GetClubByGuid(Guid guid)
        {
            return await dbSet.Where(Club => Club.IsDeleted == false && Club.Guid == guid)
                .FirstOrDefaultAsync();
        }
        public virtual async Task<tblClub> GetClubById(int clubid)
        {
            return await dbSet.Where(Club => Club.IsDeleted == false && Club.ClubId == clubid)
            .FirstOrDefaultAsync();
        }
        public virtual async Task<bool> IsClubNameExistsInSameSite(string clubNameAr, string clubNameEn, int siteId)
        {
            return await dbSet.AnyAsync(c =>
                c.IsDeleted == false &&
                c.siteId == siteId &&
                (c.ClubNameAR.ToLower() == clubNameAr.ToLower() ||
                 c.ClubNameEN.ToLower() == clubNameEn.ToLower())
            );
        }
        public virtual async Task<IList<tblClub>> GetClubsBySiteId(int siteId)
        {
            try
            {
                return await dbSet
                    .Include(c => c.Site) // تضمين بيانات الجهة
                    .Where(c => c.siteId == siteId && c.IsDeleted == false && c.IsActive == true)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetClubsBySiteId: {ex.Message}");
                return new List<tblClub>();
            }
        }
        public virtual async Task<int> InsertClub(tblClub Club)
        {
            try
            {
                await InsertAsync(Club);
                return 1;
            }
            catch (Exception ex)

            {
                Console.WriteLine($"Error inserting system:{ex.Message}");
                return 0;
            }
        }

        public virtual async Task<int> updateClub(tblClub club)
        {
            try
            {
                await UpdateAsync(club);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public virtual async Task<int> DeleteClub(tblClub club)
        {
            try
            {
                await UpdateAsync(club);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        
    }
}
