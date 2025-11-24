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
                    ClubId = club.ClubId, // Use null-coalescing instead of cast
                    Topic = viewModel.Topic,
                    Path = viewModel.Path,
                };

                int check = await _ReportRepository.InsertReport(Report);
                return check;
            }
            catch
            {
                return 0;
            }
        }
    }
}
