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
            catch (Exception ex) 
            {
                Console.WriteLine($"Error inserting system:{ex.Message}");
                return 0;
            }
        }
        public virtual async Task<IList<tblSite>> GetAllSites()
        {
            return await dbSet.Where(site => site.IsActive == true).ToListAsync(); 
        }
        public virtual async Task<tblSite> GetSiteBySiteId(int siteId)
        {
            return await dbSet.Where(site => site.IsDeleted == false && site.SiteId == siteId)
                            .FirstOrDefaultAsync();
        }
        public virtual async Task<int> updateSite(tblSite site)
        {
            try
            {
                await UpdateAsync(site);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        
        

    }
}
