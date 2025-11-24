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

    public class SystemRoleDomain(SystemRoleRepository Repository) : BaseDomain
    {
        private readonly SystemRoleRepository _SystemRoleRepository = Repository;


        public async Task<IList<SystemRoleViewModel>> GetSystemRole()
        {
            return _SystemRoleRepository.GetAllSystemRole().Result.Select(sr => new SystemRoleViewModel
            {
                guid = sr.Guid,
                SystemRoleId = sr.SystemRoleId,
                RoleTypeAr = sr.RoleTypeAr,
                RoleTypeEn = sr.RoleTypeEn,

            }).ToList() ?? new List<SystemRoleViewModel>();
        }


        public async Task<tblSystemRole> GetSystemRoleByGuid(Guid Guid)
        {
            return await _SystemRoleRepository.GetSystemRoleByGuid(Guid);
        }

        public async Task<int> InsertSystemRole(SystemRoleViewModel viewModel)
        {
            try
            {
                tblSystemRole SystemRole = new tblSystemRole
                {
                    RoleTypeAr = viewModel.RoleTypeAr,
                    RoleTypeEn = viewModel.RoleTypeEn,

                };
                int check = await _SystemRoleRepository.InsertSystemRole(SystemRole);
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
                        Table = "tblSystemRole",
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

        public virtual async Task<int> UpdateSystemRole(SystemRoleViewModel viewModel)
        {
            try
            {
                var role = await _SystemRoleRepository.GetSystemRoleByGuid(viewModel.guid);
                if (role == null)
                {
                    return 0; // Site not found
                }

                role.RoleTypeEn = viewModel.RoleTypeEn;
                role.RoleTypeAr = viewModel.RoleTypeAr;
                int check = await _SystemRoleRepository.UpdateAsync(role);
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
        public virtual async Task<int> DeleteSystemRole(Guid guid)
        {
            try
            {
                var role = await _SystemRoleRepository.GetSystemRoleByGuid(guid);
                if (role == null)
                {
                    return 0; // Site not found
                }
                role.IsDeleted = true;
                await _SystemRoleRepository.UpdateAsync(role); 
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}