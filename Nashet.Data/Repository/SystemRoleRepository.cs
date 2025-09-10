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
    public class SystemRoleRepository : BaseRepository<tblSystemRole>
    {
        public SystemRoleRepository(NashetContext dbContext) : base(dbContext)
        {

        }


        public virtual async Task<IList<tblSystemRole>> GetAllSystemRole()
        {
            return await dbSet.Where(SR => SR.IsDeleted == false).ToListAsync();
        }

    }
}
