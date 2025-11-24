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
                Console.WriteLine($"خطأ في الإضافة:{ex.Message}");
                return 0;
            }
        }
        public virtual async Task<IList<tblSite>> GetAllSites()
        {
            return await dbSet.Where(site => site.IsActive == true && site.IsDeleted == false).ToListAsync(); 
        }
        public virtual async Task<tblSite> GetSiteByGUID(Guid guid)
        {
            return await dbSet.Where(site => site.IsDeleted == false && site.Guid == guid)
                            .FirstOrDefaultAsync();
        }
        public virtual async Task<tblSite> GetSiteByID(int id)
        {
            return await dbSet.Where(site => site.IsDeleted == false && site.SiteId == id)
                            .FirstOrDefaultAsync();
        }


        public virtual async Task<bool> IsSiteNameExists(string siteNameAr, string siteNameEn, string sitecode)
        {
            return await dbSet.AnyAsync(site =>
                site.IsDeleted == false &&
                site.SiteCode == sitecode &&
                (site.SiteNameAR.ToLower() == siteNameAr.ToLower() ||
                 site.SiteNameEn.ToLower() == siteNameEn.ToLower())
            );
        }

        public virtual async Task<int> DeleteSite(tblSite site)
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
