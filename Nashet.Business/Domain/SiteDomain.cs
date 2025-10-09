using Nashet.Business.Domain.Common;
using Nashet.Business.ViewModels;
using Nashet.Data.Models;
using Nashet.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.Domain
{
    public class SiteDomain(SiteRepository Repository) : BaseDomain
    {
        private readonly SiteRepository _SiteRepository = Repository;
        
        public async Task<IList<SiteViewModel>> GetSite()
        {
            return _SiteRepository.GetAllSites().Result.Select(s => new SiteViewModel
            {
                SiteId = s.SiteId,
                SiteCode = s.SiteCode,
                SiteNameAR = s.SiteNameAR,
                SiteNameEn = s.SiteNameEn,
                Guid = s.Guid

            }).ToList();
        }
        public virtual async Task<int> InsertSite(SiteViewModel viewModel)
        {
            try
            {
                tblSite site = new tblSite
                {
                    SiteCode = viewModel.SiteCode,
                    SiteNameAR = viewModel.SiteNameAR,
                    SiteNameEn = viewModel.SiteNameEn
                };
                int check = await _SiteRepository.InsertSite(site);
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
                        Table = "tblSite",
                        operation_date = DateTime.Now,
                        operation_type = "Insert",
                        OldValue = null,
                        // NewValue=
                    };
                    await _SystemLogsRepository.InsertLog(systemLog);
                    return 1;
                }
              
            }
            catch
            {
                return 0;
            }
        }
        public virtual async Task<int> UpdateSite(int id,SiteViewModel viewModel)
        {
            try
            {
                var site = await _SiteRepository.GetSiteBySiteId(id);
                if (site == null)
                {
                    return 0; // Site not found
                }

                site.SiteCode = viewModel.SiteCode;
                site.SiteNameAR = viewModel.SiteNameAR;
                site.SiteNameEn = viewModel.SiteNameEn;

                int check = await _SiteRepository.updateSite(site);
                if (check == 0)
                    return 0;
                else
                    return 1;
            }
            catch
            {
                return 0;
            }

        }
        public virtual async Task<int> DeleteSite(int siteId)
        {
            try
            {
                var site = await _SiteRepository.GetSiteBySiteId(siteId);
                if (site == null)
                {
                    return 0; // Site not found
                }

                int check = await _SiteRepository.DeleteSite(site);
                if (check == null)
                    return 0;
                else
                    return 1;
                
            }
            catch
            {
                return 0;
            }
        }

        public async Task<tblSite> GetSiteBySiteId(int siteId)
        {
            var Site = await _SiteRepository.GetSiteBySiteId(siteId);

            if (Site == null)
            {
                throw new KeyNotFoundException($"Site request with site Id {siteId} was not found.");
            }

            return Site;
        }

        
    }
}
