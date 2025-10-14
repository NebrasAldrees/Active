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
            return await dbSet.Where(m => m.IsActive == true).ToListAsync(); // m for club
        }

        public virtual async Task<tblClub> GetClubById(int clubid)
        {
            return await dbSet.Where(Club => Club.IsDeleted == false && Club.ClubId == clubid)
            .FirstOrDefaultAsync();
        }
        public virtual async Task<bool> IsClubNameExists(string clubNameAr, string clubNameEn, int? excludeClubId = null)
        {
            var query = dbSet.Where(c => c.IsDeleted == false);

            if (excludeClubId.HasValue)
            {
                query = query.Where(c => c.ClubId != excludeClubId.Value);
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
