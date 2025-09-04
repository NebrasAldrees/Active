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
    public class ReportRepository : BaseRepository<tblReport>
    {
        public ReportRepository(NashetContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<IList<tblReport>> GetAllReports()
        {
            return await dbSet.Where(m => m.IsDeleted == false).ToListAsync(); // m for report
        }
        public virtual async Task<int> InsertReport(tblReport Report)
        {
            try
            {
                await dbSet.AddAsync(Report);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
