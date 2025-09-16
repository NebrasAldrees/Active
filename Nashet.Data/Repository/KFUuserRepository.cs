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
    public class KFUuserRepository :BaseRepository<tblKFUuser>
    {
        public KFUuserRepository(NashetContext dbContext) : base(dbContext)
        {
            
        }
        public virtual async Task<IList<tblKFUuser>> GetAllKFUuser()
        {
            return await dbSet.Where(user => user.IsDeleted == false).ToListAsync();
        }
        public virtual async Task<tblKFUuser> GetKFUuserById(int id)
        {
            return await dbSet.Where(user => user.IsDeleted == false && user.KFUUserId == id)
                .FirstOrDefaultAsync();
        }
    }
}
