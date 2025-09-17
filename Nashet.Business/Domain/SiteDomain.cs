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
                    SiteId = viewModel.SiteId,
                    SiteCode = viewModel.SiteCode,
                    SiteNameAR = viewModel.SiteNameAR,
                    SiteNameEn = viewModel.SiteNameEn,
                    Guid = viewModel.Guid
                };
                int check = await _SiteRepository.InsertSite(site);
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
        public async Task<tblSite> GetSiteByIdAsync(int id)
        {
            var Site = await _SiteRepository.GetSiteByIdAsync(id);

            if (Site == null)
            {
                throw new KeyNotFoundException($"Site request with ID {id} was not found.");
            }

            return Site;
        }

    }
}
