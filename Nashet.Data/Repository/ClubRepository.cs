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
            return await dbSet.Where(m => m.IsDeleted == false).ToListAsync(); // m for club
        }
        public virtual async Task<int> InsertClub(tblClub Club)
        {
            try
            {
                await dbSet.AddAsync(Club);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
