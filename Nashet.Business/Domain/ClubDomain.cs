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
    public class ClubDomain(ClubRepository Repository) : BaseDomain
    {
        private readonly ClubRepository _ClubRepository = Repository;

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
        public async Task<tblClub> GetClubById(int id)
        {
            var Club = await _ClubRepository.GetClubById(id);

            if (Club == null)
            {
                throw new KeyNotFoundException($"Club request with ID {id} was not found.");
            }

            return Club;
        }
        public virtual async Task<int> InsertClub(ClubViewModel viewModel)
        {
            try
            {
                tblClub Club = new tblClub
                {
                    ClubId = viewModel.ClubId,
                    siteId = viewModel.SiteId,
                    ClubNameAR = viewModel.ClubNameAR,
                    ClubNameEN = viewModel.ClubNameEN,
                    ClubVision = viewModel.ClubVision,
                    ClubOverview = viewModel.ClubOverview,
                    ClubIcon = viewModel.ClubIcon,
                    Guid = viewModel.Guid
                };
                int check = await _ClubRepository.InsertClub(Club);
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
                        Table = "tblClub",
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
    }
}
