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
    public class AnnouncementRepository : BaseRepository<tblAnnouncement>
    {

        //retrive the photo   

        public AnnouncementRepository(NashetContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<IList<tblAnnouncement>> GetAllAnnouncement()
        {
            return await dbSet.Where(A => A.IsDeleted == false).ToListAsync();


        }
    }
}
