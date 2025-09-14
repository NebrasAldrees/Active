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

        // retrive thier data to display

        public UserRepository(NashetContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<tblUser> GetMembershipRequestById(int id)
        {
            return await dbSet.Where(User => User.IsDeleted == false && User.UserId == id)
                .FirstOrDefaultAsync(); 
        }
    }
}
