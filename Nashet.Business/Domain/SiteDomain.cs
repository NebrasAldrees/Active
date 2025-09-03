using Nashet.Business.Domain.Common;
using Nashet.Data.Models;
using Nashet.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.Domain
{
    public class SiteDomain : BaseDomain
    {
        private readonly SiteRepository _SiteRepository;
        public SiteDomain(SiteRepository Repository)
        {
            _SiteRepository = Repository;
        }
        public async Task<IList<tblSite>> GetSite()
        {
            return await _SiteRepository.GetAllSites();
        }
        
    }
}
