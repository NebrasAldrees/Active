using Nashet.Business.Domain.Common;
using Nashet.Business.ViewModels;
using Nashet.Data.Models;
using Nashet.Data.Repository;
using Nashet.Data.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.Domain
{
    public class ReportDomain : BaseDomain
    {
        private readonly ReportRepository _ReportRepository;
        private readonly ClubRepository _ClubRepository;
        public ReportDomain(ReportRepository Repository, ClubRepository clubRepository)
        {
            _ReportRepository = Repository;
            _ClubRepository = clubRepository;
        }
        public async Task<IList<ReportViewModel>> GetReport()
        {
            return _ReportRepository.GetAllReports().Result.Select(a => new ReportViewModel
            {
                ReportId = a.ReportId,
                ClubId = a.ClubId,
                Topic = a.Topic,
                Path = a.Path,
                Guid = a.Guid

            }).ToList();
        }
        public async Task<tblReport> GetReportByIdAsync(int id)
        {
            var Report = await _ReportRepository.GetReportByIdAsync(id);

            if (Report == null)
            {
                throw new KeyNotFoundException($"Report request with ID {id} was not found.");
            }

            return Report;
        }
        public virtual async Task<int> InsertReport(ReportViewModel viewModel)
        {
            try
            {
                var club = await _ClubRepository.GetClubByGuid(viewModel.ClubGuid);

                tblReport Report = new tblReport
                {
                    ClubId = club.ClubId,
                    Topic = viewModel.Topic,
                    Path = viewModel.Path,
                    Guid = Guid.NewGuid()
                };

                int check = await _ReportRepository.InsertReport(Report);
                return check;
            }
            catch
            {
                return 0;
            }
        }
        public virtual async Task<List<ReportViewModel>> GetReportsByClubId(int clubId)
        {
            try
            {
                Console.WriteLine($"GetReportsByClubId called with clubId: {clubId}");

                var reports = await _ReportRepository.GetReportsByClubId(clubId);

                Console.WriteLine($"Raw reports count from repository: {reports?.Count ?? 0}");

                if (reports == null || !reports.Any())
                {
                    Console.WriteLine($"No reports found for clubId: {clubId}");
                    return new List<ReportViewModel>();
                }

                var reportViewModels = reports.Select(r => new ReportViewModel
                {
                    ReportId = r.ReportId,
                    ClubId = r.ClubId,
                    Topic = r.Topic,
                    Path = r.Path,
                    Guid = r.Guid,
                    IsAdded = r.IsAdded,
                    ClubNameAr = r.Club?.ClubNameAR
                }).ToList();

                Console.WriteLine($"Mapped {reportViewModels.Count} reports for clubId: {clubId}");

                // طباعة بعض البيانات للتأكد
                foreach (var report in reportViewModels.Take(3))
                {
                    Console.WriteLine($"Report: Id={report.ReportId}, Topic={report.Topic}, ClubId={report.ClubId}");
                }

                return reportViewModels;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetReportsByClubId: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                return new List<ReportViewModel>();
            }
        }
    }
}
