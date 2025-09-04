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
    public class TeamRepository : BaseRepository<tblTeam>
    {
        public TeamRepository(NashetContext dbContext) : base(dbContext)
        {
        }
        public virtual async Task<IList<tblTeam>> GetAllTeams()
        {
            return await dbSet.Where(team => team.IsActive == true).ToListAsync(); 
        }
        public virtual async Task<int> InsertTeam(tblTeam Team)
        {
            try
            {
                await dbSet.AddAsync(Team);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
