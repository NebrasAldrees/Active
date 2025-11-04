using Nashet.Business.Domain.Common;
using Nashet.Business.ViewModels;
using Nashet.Data.Models;
using Nashet.Data.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.Domain
{
    public class AnnouncementDomain : BaseDomain
    {
        private readonly AnnouncementRepository _AnnouncementRepository;
        private readonly ClubRepository _ClubRepository;
        public AnnouncementDomain(AnnouncementRepository announcementRepository, ClubRepository ClubRepository)
        {
            _AnnouncementRepository = announcementRepository;
            _ClubRepository = ClubRepository;
        }

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
        public async Task<AnnouncementViewModel> GetAnnouncementByGuid(Guid guid)
        {
            var announcement = await _AnnouncementRepository.GetAnnouncementByGuid(guid);
            if (announcement == null)
                throw new KeyNotFoundException($"Announcement with GUID {guid} was not found.");

            return new AnnouncementViewModel
            {
                AnnouncementId = announcement.AnnouncementId,
                ClubId = announcement.ClubId,
                AnnouncementType = announcement.AnnouncementType,
                AnnouncementTopic = announcement.AnnouncementTopic,
                AnnouncementDetails = announcement.AnnouncementDetails,
                AnnouncementImage = announcement.AnnouncementImage,
                Guid = announcement.Guid
            };
        }

        public async Task<IList<AnnouncementViewModel>> GetLatestAnnouncements(int count = 3)
        {
            var announcements = await _AnnouncementRepository.GetLatestAnnouncements(count);

            return announcements.Select(a => new AnnouncementViewModel
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
                var club = await _ClubRepository.GetClubByGuid(viewModel.ClubGuid);
                tblAnnouncement announcement = new tblAnnouncement
                {
                    ClubId = club.ClubId,
                    AnnouncementType = viewModel.AnnouncementType,
                    AnnouncementTopic = viewModel.AnnouncementTopic,
                    AnnouncementDetails = viewModel.AnnouncementDetails,
                    AnnouncementImage = viewModel.AnnouncementImage,
                    Guid = Guid.NewGuid()
                };
                int check = await _AnnouncementRepository.InsertAnnouncement(announcement);
                if (check == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch
            {
                return 0;
            }
        }
        public virtual async Task<int> UpdateAnnouncement(AnnouncementViewModel viewModel)
        {
            try
            {
                var announcement = await _AnnouncementRepository.GetAnnouncementByGuid(viewModel.Guid);
                if (announcement == null)
                {
                    return 0; // Site not found
                }
                var club = await _ClubRepository.GetClubByGuid(viewModel.ClubGuid);
                announcement.ClubId = club.ClubId;
                announcement.AnnouncementType = viewModel.AnnouncementType;
                announcement.AnnouncementTopic = viewModel.AnnouncementTopic;
                announcement.AnnouncementDetails = viewModel.AnnouncementDetails;
                announcement.AnnouncementImage = viewModel.AnnouncementImage;

                int check = await _AnnouncementRepository.UpdateAnnouncement(announcement);
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

        public async Task<bool> DeleteAnnouncement(Guid guid)
        {
            try
            {
                var announcement = await _AnnouncementRepository.GetAnnouncementByGuid(guid);
                if (announcement == null)
                    return false;

                // Soft Delete (تغيير حالة IsDeleted)
                announcement.IsDeleted = true;
                await _AnnouncementRepository.UpdateAsync(announcement);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

