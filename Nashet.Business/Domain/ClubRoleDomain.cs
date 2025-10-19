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

        public async Task<tblClubRole> GetClubRoleByGuid(Guid Guid)
        {
            return await _ClubRoleRepository.GetClubRoleByGuid(Guid);
        }
        public async Task<IList<ClubRoleViewModel>> GetClubRole()
        {
            return _ClubRoleRepository.GetAllClubRole().Result.Select(c => new ClubRoleViewModel
            {
                Guid = c.Guid,
                ClubRoleId = c.ClubRoleId,
                RoleTypeAr = c.RoleTypeAr,
                RoleTypeEn = c.RoleTypeEn,
               

            }).ToList();
        }


        public async Task<int> InsertClubRole(ClubRoleViewModel viewModel)
        {
            try
            {
                tblClubRole clubrole = new tblClubRole
                {

                
                    RoleTypeAr = viewModel.RoleTypeAr,
                    RoleTypeEn = viewModel.RoleTypeEn,
                    
                };
                int check = await _ClubRoleRepository.InsertClubRole(clubrole);
                if (check == 0)
                    return 0;

                else
                {
                    var systemLog = new tblSystemLogs
                    {
                        UserId = 23456,
                        username = "najd",
                        RecordId = 17,
                        Table = "tblClubRole",
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

        public virtual async Task<int> UpdateClubRole(ClubRoleViewModel viewModel)
        {
            try
            {
                var clubrole = await _ClubRoleRepository.GetClubRoleByGuid(viewModel.Guid);
                if (clubrole == null)
                {
                    return 0;
                }

                clubrole.RoleTypeAr = viewModel.RoleTypeAr;
                clubrole.RoleTypeEn = viewModel.RoleTypeEn;

                int check = await _ClubRoleRepository.UpdateClubRole(clubrole);
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
        public virtual async Task<int> DeleteClubRole(Guid Guid)
        {
            try
            {
                var clubrole = await _ClubRoleRepository.GetClubRoleByGuid(Guid);
                if (clubrole == null)
                {
                    return 0;
                }

                int check = await _ClubRoleRepository.DeleteClubRole(clubrole);
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
