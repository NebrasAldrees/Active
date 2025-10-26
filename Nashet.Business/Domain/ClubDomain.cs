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
    public class ClubDomain: BaseDomain
    {
        private readonly ClubRepository _ClubRepository;
        private readonly SiteRepository _SiteRepository;
        public ClubDomain(SiteRepository siteRepository, ClubRepository Repository)
        {
            _SiteRepository = siteRepository;
            _ClubRepository = Repository;
        }

        public async Task<IList<ClubViewModel>> GetClub()
        {
            return _ClubRepository.GetAllClubs().Result.Select(a => new ClubViewModel
            {
                ClubId = a.ClubId,
                SiteId = a.siteId,
                ClubNameAR = a.ClubNameAR,
                ClubNameEN = a.ClubNameEN,
                ClubVision = a.ClubVision,
                ClubOverview = a.ClubOverview,
                ClubIcon = a.ClubIcon,
                Guid = a.Guid

            }).ToList();
        }
        public async Task<ClubViewModel> GetClubByGuid(Guid guid)
        {
            var club = await _ClubRepository.GetClubByGuid(guid);
            if (club == null)
            {
                throw new KeyNotFoundException($"Club with GUID {guid} was not found.");
            }

            return new ClubViewModel
            {
                ClubId = club.ClubId,
                SiteId = (int)club.siteId,
                ClubNameAR = club.ClubNameAR,
                ClubNameEN = club.ClubNameEN,
                ClubVision = club.ClubVision,
                ClubOverview = club.ClubOverview,
                ClubIcon = club.ClubIcon,
                Guid = club.Guid
            };
        }
        public async Task<ClubViewModel> GetClubById(int id)
        {
            var club = await _ClubRepository.GetClubById(id);

            if (club == null)
            {
                throw new KeyNotFoundException($"Club with ID {id} was not found.");
            }

            return new ClubViewModel
            {
                ClubId = club.ClubId,
                SiteId = club.siteId,
                ClubNameAR = club.ClubNameAR,
                ClubNameEN = club.ClubNameEN,
                ClubVision = club.ClubVision,
                ClubOverview = club.ClubOverview,
                ClubIcon = club.ClubIcon,
                Guid = club.Guid
            };
        }
        public virtual async Task<int> InsertClub(ClubViewModel viewModel)
        {
            try
            {
                var site = await _SiteRepository.GetSiteByGUID(viewModel.SiteGuid);
                tblClub Club = new tblClub
                {
                    siteId = site.SiteId,
                    ClubNameAR = viewModel.ClubNameAR,
                    ClubNameEN = viewModel.ClubNameEN,
                    ClubVision = viewModel.ClubVision,
                    ClubOverview = viewModel.ClubOverview,
                    ClubIcon = viewModel.ClubIcon,
                    Guid = Guid.NewGuid()
                };
                int check = await _ClubRepository.InsertClub(Club);
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
        public virtual async Task<int> UpdateClubByGuid(Guid guid, ClubViewModel viewModel)
        {
            try
            {
                bool nameExists = await _ClubRepository.IsClubNameExists(viewModel.ClubNameAR, viewModel.ClubNameEN, guid);
                if (nameExists)
                {
                    return -1;
                }

                var updatedClub = new tblClub
                {
                    siteId = viewModel.SiteId,
                    ClubNameAR = viewModel.ClubNameAR,
                    ClubNameEN = viewModel.ClubNameEN,
                    ClubVision = viewModel.ClubVision,
                    ClubOverview = viewModel.ClubOverview,
                    ClubIcon = viewModel.ClubIcon
                };

                int check = await _ClubRepository.UpdateClubByGuid(guid, updatedClub);
                return check == 0 ? 0 : 1;
            }
            catch
            {
                return 0;
            }
        }
        public virtual async Task<int> DeleteClubByGuid(Guid guid)
        {
            try
            {
                int check = await _ClubRepository.DeleteClubByGuid(guid);
                return check == 0 ? 0 : 1;
            }
            catch
            {
                return 0;
            }
        }
        
        
    }
}
