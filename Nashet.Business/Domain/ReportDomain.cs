using Nashet.Business.Domain.Common;
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
        public async Task<IList<tblReport>> GetReport()
        {
            return await _ReportRepository.GetAllReports();
        }
        public virtual async Task<int> InsertReport(tblReport Report)
        {
            try
            {
                await _ReportRepository.InsertReport(Report);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
