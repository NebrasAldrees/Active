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
        public ClubRoleRepository (NashetContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<IList<tblClubRole>> GetAllClubRole()
        {
            return await dbSet.Where(ClubR => ClubR.IsDeleted == false).ToListAsync(); 
        }

        public virtual async Task<tblClubRole> GetClubRoleById(int id)
        {
            return await dbSet.Where(ClubRole => ClubRole.IsDeleted == false && ClubRole.ClubRoleId == id)
            .FirstOrDefaultAsync();
        }
    }
}
