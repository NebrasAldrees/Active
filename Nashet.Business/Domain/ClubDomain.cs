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
    public class ClubDomain(ClubRepository Repository) : BaseDomain
    {
        private readonly ClubRepository _ClubRepository = Repository;

        public async Task<IList<tblClub>> GetMember()
        {
            return await _ClubRepository.GetAllClubs();
        }
        public virtual async Task<int> InsertClub(tblClub Club)
        {
            try
            {
                await _ClubRepository.InsertClub(Club);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
