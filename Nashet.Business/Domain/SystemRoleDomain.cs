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
    
        public class SystemRoleDomain(SystemRoleRepository Repository) : BaseDomain
        {
            private readonly SystemRoleRepository _SystemRoleRepository = Repository;

            public async Task<IList<tblSystemRole>> GetSystemRole()
            {
                return await _SystemRoleRepository.GetAllSystemRole();
            }
            public async Task<tblSystemRole> GetSystemRoleByIdAsync(int id)
            {
                var SystemRole = await _SystemRoleRepository.GetSystemRoleByIdAsync(id);
                
                if (SystemRole == null)
                {
                 throw new KeyNotFoundException($"System Role request with ID {id} was not found.");
                }
    
                return SystemRole;
            }

        }
    
    }

