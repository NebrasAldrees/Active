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
        public class AnnouncementDomain(AnnouncementRepository Repository) : BaseDomain
        {
        private readonly AnnouncementRepository _AnnouncementRepository = Repository;

        public async Task<IList<AnnouncementViewModel>> GetAnnouncement()
        {
            return _AnnouncementRepository.GetAllAnnouncement().Result.Select(a => new AnnouncementViewModel
            {
                AnnouncementId = a.AnnouncementId,
                ClubId = a.ClubId,
                AnnouncementType = a.AnnouncementType,
                AnnouncementTopic = a.AnnouncementTopic,
                AnnouncementDetails = a.AnnouncementDetails,
                AnnouncementImage = a.AnnouncementImage,
                Guid = a.Guid
            }).ToList();
        }
        public virtual async Task<int> InsertAnnouncement(AnnouncementViewModel viewModel)
        {
            try
            {
                tblAnnouncement announcement = new tblAnnouncement
                {
                    AnnouncementId = viewModel.AnnouncementId,
                    ClubId = viewModel.ClubId,
                    AnnouncementType = viewModel.AnnouncementType,
                    AnnouncementTopic = viewModel.AnnouncementTopic,
                    AnnouncementDetails = viewModel.AnnouncementDetails,
                    AnnouncementImage = viewModel.AnnouncementImage
                };
                int check = await _AnnouncementRepository.InsertAnnouncement(announcement);
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
                        Table = "tblAnnouncement",
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
        public async Task<tblAnnouncement> GetAnnouncementByIdAsync(int id)
        {
            var Aannouncement = await _AnnouncementRepository.GetAnnouncementByIdAsync(id);

            if (Aannouncement == null)
            {
                throw new KeyNotFoundException($"Announcement requested with ID {id} was not found.");
            }

            return Aannouncement;
        }
    }
    }

