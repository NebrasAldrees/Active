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

        public virtual async Task<IList<tblReport>> GetAllReports(int id)
        {
            return await dbSet.Where(report => report.IsDeleted == false && report.ClubId == id).ToListAsync(); 
        }

        public async Task<IList<tblReport>> GetAllReports()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<tblReport> GetReportByIdAsync(int id)
        {
            return await dbSet.Where(report => report.IsDeleted == false && report.ReportId == id)
                            .FirstOrDefaultAsync();
        }
        public virtual async Task<int> InsertReport(tblReport Report)
        {
            try
            {
                await InsertAsync(Report);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
