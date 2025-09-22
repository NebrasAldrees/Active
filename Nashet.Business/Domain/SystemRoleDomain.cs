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

    public class SystemRoleDomain(SystemRoleRepository Repository) : BaseDomain
    {
        private readonly SystemRoleRepository _SystemRoleRepository = Repository;


        public async Task<IList<SystemRoleViewModel>> GetSystemRole()
        {
            return _SystemRoleRepository.GetAllSystemRole().Result.Select(sr => new SystemRoleViewModel
            {
                guid = sr.Guid,
                SystemRoleId = sr.SystemRoleId,
                RoleType = sr.RoleType,

            }).ToList();
        }
        public async Task<int> InsertSystemRole(SystemRoleViewModel viewModel)
        {
            try
            {
                tblSystemRole SystemRole = new tblSystemRole
                {
                    SystemRoleId = viewModel.SystemRoleId,
                    RoleType = viewModel.RoleType,

                };
                int check = await _SystemRoleRepository.InsertSystemRole(SystemRole);
                if (check == 0)
                    return 0;
                else
                    return 1;
                {
                }

            }
            catch
            {
                return 0;
            }
            {
            }
        }
    }
}

