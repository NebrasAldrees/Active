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
        public async Task<IList<ClubViewModel>> GetClubBySiteGuid(Guid? SiteGuid)
        {
            try
            {
                Console.WriteLine($"GetClubBySiteGuid called with SiteGuid: {SiteGuid}");

                if (SiteGuid.HasValue)
                {
                    var site = await _SiteRepository.GetSiteByGUID(SiteGuid.Value);
                    if (site == null)
                    {
                        Console.WriteLine("Site not found for the provided GUID");
                        return new List<ClubViewModel>();
                    }

                    Console.WriteLine($"Found site: {site.SiteNameAR} with ID: {site.SiteId}");

                    var clubs = await _ClubRepository.GetClubsBySiteId(site.SiteId);

                    Console.WriteLine($"Found {clubs?.Count ?? 0} clubs for site ID: {site.SiteId}");

                    var result = clubs?.Select(a => new ClubViewModel
                    {
                        ClubId = a.ClubId,
                        SiteId = a.siteId,
                        ClubNameAR = a.ClubNameAR,
                        ClubNameEN = a.ClubNameEN,
                        ClubVision = a.ClubVision,
                        ClubOverview = a.ClubOverview,
                        ClubIcon = a.ClubIcon,
                        Guid = a.Guid
                    }).ToList() ?? new List<ClubViewModel>();

                    return result;
                }
                else
                {
                    return await GetClub();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetClubBySiteGuid: {ex.Message}");
                return new List<ClubViewModel>();
            }
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

                bool nameExists = await _ClubRepository.IsClubNameExistsInSameSite(viewModel.ClubNameAR, viewModel.ClubNameEN, site.SiteId);
                if (nameExists)
                {
                    return -1;
                }

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
       
        public virtual async Task<int> UpdateClub(ClubViewModel viewModel)
        {
            try
            {
                var club = await _ClubRepository.GetClubByGuid(viewModel.Guid);
                if (club == null)
                {
                    return 0;
                }
                var site = await _SiteRepository.GetSiteByGUID(viewModel.SiteGuid);

                club.ClubNameAR = viewModel.ClubNameAR;
                club.ClubNameEN = viewModel.ClubNameEN;
                club.ClubVision = viewModel.ClubVision;
                club.ClubOverview = viewModel.ClubOverview;
                club.ClubIcon = viewModel.ClubIcon;
                club.siteId = site.SiteId;
                
                int check = await _ClubRepository.updateClub(club);
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


        public async Task<bool> DeleteClub(Guid guid)
        {
            try
            {
                var club = await _ClubRepository.GetClubByGuid(guid);
                if (club == null)
                    return false;

                club.IsDeleted = true;
                await _ClubRepository.UpdateAsync(club);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        } 
        
    }
}
