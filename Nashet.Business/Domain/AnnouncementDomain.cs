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
            public async Task<tblAnnouncement> GetAnnouncementByIdAsync(int id)
            {
                var Announcement = await _AnnouncementRepository.GetAnnouncementByIdAsync(id);
                
                if (Announcement == null)
                {
                    throw new KeyNotFoundException($"Announcement request with ID {id} was not found.");
                }
                
                return Announcement;
            }
            public virtual async Task<int> InsertAnnouncement(tblAnnouncement Announcement)
            {
                try
                {
                    await _AnnouncementRepository.InsertAnnouncement(Announcement);
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        public int DeleteAnnouncement(int id)
            {
                try
                {
                    _AnnouncementRepository.Delete(id);
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }

        }
    }

