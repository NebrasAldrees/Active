using Azure.Core;
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
    public class ActivityRequestRepository : BaseRepository<tblActivityRequest>
    {

   
        public ActivityRequestRepository(NashetContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<IList<tblActivityRequest>> GetAllRequests()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<tblActivityRequest> GetRequestByGUID(Guid guid)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(Request => Request.Guid == guid);
        }

        public virtual async Task<int> InsertActivityRequest(tblActivityRequest request)
        {
            try
            {
                await InsertAsync(request);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"خطأ في الإضافة:{ex.Message}");
                return 0;
            }
        }
        public virtual async Task<int> AcceptActivityRequest(tblActivityRequest Request)
        {
            try
            {
                await UpdateAsync(Request);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public virtual async Task<int> DeleteActivityRequest(tblActivityRequest Request)
        {
            try
            {
                await UpdateAsync(Request);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
