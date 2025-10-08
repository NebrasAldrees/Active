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
    public class ClubRoleRepository : BaseRepository<tblClubRole>
    {
        public ClubRoleRepository(NashetContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<IList<tblClubRole>> GetAllClubRole()
        {
            return await dbSet.Where(clubrole => clubrole.IsDeleted == false).ToListAsync();
        }
        public virtual async Task<tblClubRole> GetClubRoleByIdAsync(int id)
        {
            return await dbSet.Where(clubrole => clubrole.IsDeleted == false && clubrole.ClubRoleId == id)
                            .FirstOrDefaultAsync();
        }
        public virtual async Task<int> InsertClubRole(tblClubRole ClubRole)
        {
            try
            {

                await InsertAsync(ClubRole);
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
