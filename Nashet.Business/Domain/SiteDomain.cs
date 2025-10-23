﻿using Nashet.Business.Domain.Common;
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
                SiteCode = s.SiteCode,
                SiteNameAR = s.SiteNameAR,
                SiteNameEn = s.SiteNameEn,
                Guid = s.Guid

            }).ToList();
        }
        public async Task<tblSite> GetSiteByGUID(Guid guid)
        {
            var Site = await _SiteRepository.GetSiteByGUID(guid);

            if (Site == null)
            {
                throw new KeyNotFoundException($"Site request with site GUId {guid} was not found.");
            }

            return Site;
        }
        public virtual async Task<int> InsertSite(SiteViewModel viewModel)
        {
            try
            {
                tblSite site = new tblSite
                {
                    Guid = Guid.NewGuid(),
                    SiteId = viewModel.SiteId,
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
                    //await _SystemLogsRepository.InsertLog(systemLog);
                    return 1;
                }
              
            }
            catch
            {
                return 0;
            }
        }
        public virtual async Task<int> UpdateSite(SiteViewModel viewModel)
        {
            try
            {
                var site = await _SiteRepository.GetSiteByGUID(viewModel.Guid);
                if (site == null)
                {
                    return 0; // Site not found
                }

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
        public virtual async Task<int> DeleteSite(Guid guid)
        {
            try
            {
                var site = await _SiteRepository.GetSiteByGUID(guid);
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

        

        
    }
}
