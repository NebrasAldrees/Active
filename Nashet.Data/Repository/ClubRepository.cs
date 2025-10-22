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
            //public virtual async Task<int> DeleteClub(int id)
            //{
            //    try
            //    {
            //        var club = await dbSet.FindAsync(id);
            //        if (club != null)
            //        {
            //            club.IsDeleted = true;
            //            await NashetContext.SaveChangesAsync();
            //            return 1;
            //        }
            //        return 0; 
            //    }
            //    catch
            //    {
            //        return 0;
            //    }
            //}
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
    }
}
