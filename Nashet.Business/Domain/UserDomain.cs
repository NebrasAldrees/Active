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
 
    
        public class UserDomain(UserRepository Repository) : BaseDomain
        {
            private readonly UserRepository _UserRepository = Repository;

            public async Task<IList<tblUser>> GetUser()
            {
                return await _UserRepository.GetAllUsers();
            }
        }
}
