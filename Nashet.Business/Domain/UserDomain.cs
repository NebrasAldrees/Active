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
            public async Task<tblUser> GetUserByIdAsync(int id)
            {
                var UserRepository = await _UserRepository.GetUserByIdAsync(id);
                
                if (UserRepository == null)
                {
                     throw new KeyNotFoundException($"User request with ID {id} was not found.");
                }
    
                return UserRepository;
            }
            public virtual async Task<int> InsertUser(tblUser user)
            {
                try
                {
                    await _UserRepository.InsertUser(user);
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        public int DeleteUser(int id)
            {
                try
                {
                    _UserRepository.Delete(id);
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }

    }

}
