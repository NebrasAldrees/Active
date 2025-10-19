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
            return await dbSet.Where(Report => Report.IsDeleted == false).ToListAsync();
        }
        public virtual async Task<tblReport> GetReportByGuid(Guid guid)
        {
            return await dbSet.Where(Report => Report.IsDeleted == false && Report.Guid == guid)
                .FirstOrDefaultAsync();
        }
        public virtual async Task<tblReport> GetReportByIdAsync(int id)
        {
            return await dbSet.Where(report => report.IsDeleted == false && report.ReportId == id)
            .FirstOrDefaultAsync();
        }
        public virtual async Task<IList<tblReport>> GetReportsByClubGuid(Guid clubGuid)
        {
            return await dbSet
                .Include(r => r.Club)
                .Where(r => r.IsDeleted == false && r.Club.Guid == clubGuid)
                .OrderByDescending(r => r.CreationDate)
                .ToListAsync();
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
