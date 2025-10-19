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
            return await dbSet.Where(m => m.IsDeleted == false).ToListAsync();
        }
        public virtual async Task<tblClub> GetClubByGuid(Guid guid)
        {
            return await dbSet.Where(Club => Club.IsDeleted == false && Club.Guid == guid)
                .FirstOrDefaultAsync();
        }
        public virtual async Task<tblClub> GetClubById(int clubid)
        {
            return await dbSet.Where(Club => Club.IsDeleted == false && Club.ClubId == id)
            .FirstOrDefaultAsync();
        }
        public virtual async Task<bool> IsClubNameExists(string clubNameAr, string clubNameEn, Guid? excludeClubGuid = null)
        {
            var query = dbSet.Where(c => c.IsDeleted == false);

            if (excludeClubGuid.HasValue)
            {
                query = query.Where(c => c.Guid != excludeClubGuid.Value);
            }

            return await query.AnyAsync(c =>
                c.ClubNameAR == clubNameAr ||
                c.ClubNameEN == clubNameEn
            );
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
        public virtual async Task<int> DeleteClubByGuid(Guid guid)
        {
            try
            {
                var club = await GetClubByGuid(guid);
                if (club == null || club.IsDeleted == true)
                {
                    return 0;
                }
                IsDeleted(club);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public virtual async Task<int> UpdateClubByGuid(Guid guid, tblClub updatedClub)
        {
            try
            {
                var club = await GetClubByGuid(guid);
                if (club == null)
                {
                    return 0;
                }

                club.siteId = updatedClub.siteId;
                club.ClubNameAR = updatedClub.ClubNameAR;
                club.ClubNameEN = updatedClub.ClubNameEN;
                club.ClubVision = updatedClub.ClubVision;
                club.ClubOverview = updatedClub.ClubOverview;
                club.ClubIcon = updatedClub.ClubIcon;

                await UpdateAsync(club);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public virtual async Task<int> DeleteClub (tblClub club)
        {
            try
            {
                if (club == null || club.IsDeleted == true)
                {
                    return 0;
                }
                IsDeleted(club);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public virtual async Task<int> UpdateClub (tblClub club)
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
