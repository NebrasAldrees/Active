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
        public async Task<tblClubRole> GetClubRoleById(int id)
        {
            var ClubRole = await _ClubRoleRepository.GetClubRoleById(id);

            if (ClubRole == null)
            {
                throw new KeyNotFoundException($"Club Role requested with ID {id} was not found.");
            }

            return ClubRole;
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
