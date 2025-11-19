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
    public class StatusRepository : BaseRepository<tblStatus>
    {
        public StatusRepository(NashetContext dbContext) : base(dbContext)
        {
        }
        public virtual async Task<IList<tblStatus>> GetAllStatusType()
        {
            return await dbSet.Where(status => status.IsDeleted == false).ToListAsync();
        }

        public virtual async Task<int> InsertStatusType(tblStatus status)
        {
            try
            {
                await InsertAsync(status);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"خطأ في الإضافة:{ex.Message}");
                return 0;
            }
        }
        public virtual async Task<tblStatus> GetAllStatusTypeByIdAsync(int id)
        {
            return await dbSet.Where(Status => Status.IsDeleted == false && Status.StatusId == id)
                            .FirstOrDefaultAsync();
        }
        public virtual async Task<tblStatus> GetAllStatusTypeByGuid(Guid guid)
        {
            return await dbSet.Where(Status => Status.IsDeleted == false && Status.Guid == guid)
                            .FirstOrDefaultAsync();
        }
    }
}
