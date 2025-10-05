using Nashet.Business.Domain.Common;
using Nashet.Business.ViewModels;
using Nashet.Data.Models;
using Nashet.Data.Repository;
using Nashet.Data.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.Domain
{
    public class ClubRoleDomain(ClubRoleRepository Repository) : BaseDomain
    {
        private readonly ClubRoleRepository _ClubRoleRepository = Repository;
        public async Task<IList<ClubRoleViewModel>> GetClubRole()
        {
            return _ClubRoleRepository.GetAllClubRole().Result.Select(c => new ClubRoleViewModel
            {
                ClubRoleId = c.ClubRoleId,
                RoleType = c.RoleType,
                Guid = c.Guid,

            }).ToList();
        }


        public async Task<int> InsertClubRole(ClubRoleViewModel viewModel)
        {
            try
            {
                tblClubRole clubrole = new tblClubRole
                {

                    ClubRoleId = viewModel.ClubRoleId,
                    RoleType = viewModel.RoleType,
                    Guid = viewModel.Guid
                };
                int check = await _ClubRoleRepository.InsertClubRole(clubrole);
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
        public int DeleteClubRole(int id)
        {
            try
            {
                _ClubRoleRepository.Delete(id);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
