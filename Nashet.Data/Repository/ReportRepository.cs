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
        private readonly NashetContext _context;
        public ReportRepository(NashetContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public virtual async Task<IList<tblReport>> GetAllReports()
        {
            return await dbSet.Where(Report => Report.IsDeleted == false).ToListAsync();
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting report: {ex.Message}");
                return 0;
            }
        }
        public virtual async Task<List<tblReport>> GetReportsByClubId(int clubId)
        {
            try
            {
                Console.WriteLine($"Repository GetReportsByClubId called with clubId: {clubId}");

                // تحقق من أن dbSet ليس null
                if (dbSet == null)
                {
                    Console.WriteLine("dbSet is NULL!");
                    return new List<tblReport>();
                }

                var reports = await dbSet
                    .Where(r => r.ClubId == clubId && r.IsDeleted == false)
                    .Include(r => r.Club)
                    .OrderByDescending(r => r.ReportId)
                    .ToListAsync();

                Console.WriteLine($"Repository found {reports.Count} reports");

                // طباعة بعض البيانات للتأكد
                foreach (var report in reports.Take(3))
                {
                    Console.WriteLine($"DB Report: Id={report.ReportId}, Topic={report.Topic}, ClubId={report.ClubId}, IsDeleted={report.IsDeleted}");
                }

                return reports;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Repository GetReportsByClubId: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                return new List<tblReport>();
            }
        }
    }
}
