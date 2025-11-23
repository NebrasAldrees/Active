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
                tblReport Report = new tblReport
                {
                    ClubId = (int)viewModel.ClubId,
                    Topic = viewModel.Topic,
                    Path = viewModel.Path
                };
                int check = await _ReportRepository.InsertReport(Report);
                if (check == 0)
                {
                    return 0;
                }
                else
                {
                    var systemLog = new tblSystemLogs
                    {
                        UserId = 23456,
                        username = "najd",
                        RecordId = 17,
                        Table = "tblReport",
                        operation_date = DateTime.Now,
                        operation_type = "Insert",
                        OldValue = null,
                        // NewValue=
                    };
                    //await _SystemLogsRepository.InsertLog(systemLog);
                    return 1;
                }
              
            }
            catch
            {
                return 0;
            }
        }
    }
}
