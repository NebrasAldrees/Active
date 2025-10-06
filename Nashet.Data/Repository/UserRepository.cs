using Microsoft.EntityFrameworkCore;
using Nashet.Data.Models;
using Nashet.Data.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Repository
{
    public class UserRepository: BaseRepository<tblUser>
    {
        public UserRepository(NashetContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<IList<tblUser>> GetAllUsers()
        {
            return await dbSet.Where(user => user.IsDeleted == false).ToListAsync(); 
        }
        public virtual async Task<tblUser> GetUserByIdAsync(int id)
        {
            return await dbSet.Where(user => user.IsDeleted == false && user.UserId == id)
                            .FirstOrDefaultAsync();
        }
        public virtual async Task<tblUser> GetUserByUsername(String username)
        {
            return await dbSet.SingleOrDefaultAsync(user => user.Username == username && !user.IsDeleted);
        }
        public virtual async Task<int> InsertUser(tblUser user)
        {
            try
            {
                await InsertAsync(user);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

    }
}
