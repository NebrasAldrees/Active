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
    public class ClubDomain
    {
     
            private readonly ClubRepository _ClubRepository;
            public ClubDomain(MembershipRepository Repository)
            {
                _ClubRepository = Repository;
            }
            public async Task<IList<tblMembership>> GetClub()
            {
                return await _ClubRepository.GetAllClub();
            }
        }
    }