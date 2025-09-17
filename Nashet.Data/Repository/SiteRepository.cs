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
    public class SiteRepository : BaseRepository<tblSite>
    {
        public SiteRepository(NashetContext dbContext) : base(dbContext)
        {
        }
        public virtual async Task<int> InsertSite(tblSite site)
        {
            try
            {
                await InsertAsync(site);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public virtual async Task<IList<tblSite>> GetAllSites()
        {
            return await dbSet.Where(site => site.IsActive == true).ToListAsync(); 
        }
        public virtual async Task<tblSite> GetSiteByIdAsync(int id)
        {
            return await dbSet.Where(site => site.IsDeleted == false && site.SiteId == id)
                            .FirstOrDefaultAsync();
        }

    }
}
