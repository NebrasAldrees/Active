using Microsoft.EntityFrameworkCore;
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
    public class ClubRoleDomain : BaseDomain
    {
        private readonly ClubRoleRepository _ClubRoleRepository;
        public ClubRoleDomain(ClubRoleRepository Repository)
        {
            _ClubRoleRepository = Repository;
        }
        public async Task<IList<tblClubRole>> GetClubRole()
        {
            return await _ClubRoleRepository.GetAllClubRole();
        }
        
    }
}
