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
        public ReportDomain(ReportRepository Repository)
        {
            _ReportRepository = Repository;
        }
        public async Task<IList<ReportViewModel>> GetReport()
        {
            return _ReportRepository.GetAllReports().Result.Select(a => new ReportViewModel
            {
                ReportId = a.ReportId,
                ClubId = (int)a.ClubId,
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

        public async Task<ReportViewModel> GetReportByGuid(Guid guid)
        {
            var report = await _ReportRepository.GetReportByGuid(guid);
            if (report == null)
            {
                throw new KeyNotFoundException($"Report with GUID {guid} was not found.");
            }

            return new ReportViewModel
            {
                ReportId = report.ReportId,
                ClubId = (int)report.ClubId,
                Topic = report.Topic,
                Path = report.Path,
                Guid = report.Guid
            };
        }
        public async Task<IList<ReportViewModel>> GetReportsByClubGuid(Guid clubGuid)
        {
            var reports = await _ReportRepository.GetReportsByClubGuid(clubGuid);
            return reports.Select(r => new ReportViewModel
            {
                ReportId = r.ReportId,
                ClubId = (int)r.ClubId,
                Topic = r.Topic,
                Path = r.Path,
                Guid = r.Guid
            }).ToList();
        }
        public virtual async Task<int> InsertReport(ReportViewModel viewModel)
        {
            try
            {
                tblReport Report = new tblReport
                {
                    ClubId = viewModel.ClubId,
                    Topic = viewModel.Topic,
                    Path = viewModel.Path, // هنا نخزن مسار الملف
                    Guid = Guid.NewGuid(),
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    IsAdded = true, // للإشارة أنه تمت إضافته
                    isSent = false // لم يتم إرساله بعد
                };

                int check = await _ReportRepository.InsertReport(Report);
                return check == 0 ? 0 : 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting report: {ex.Message}");
                return 0;
            }
        }
    }
}
