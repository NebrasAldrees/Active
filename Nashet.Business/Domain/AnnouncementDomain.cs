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
    
        public class AnnouncementDomain(AnnouncementRepository Repository) : BaseDomain
        {
            private readonly AnnouncementRepository _AnnouncementRepository = Repository;

            public async Task<IList<tblAnnouncement>> GetAnnouncement()
            {
                return await _AnnouncementRepository.GetAllAnnouncement();
            }
        }
    }

