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
    public class AdminRepository : BaseRepository<tblUser>
    {
        public AdminRepository(NashetContext dbContext) : base(dbContext)
        {
        }

        public AdminRepository(NashetContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<IList<tblUser>> GetAllMembers()
        {
            return await dbSet.Where(user => user.IsDeleted == false).ToListAsync(); // user for users except students
        }
        
    }
}
