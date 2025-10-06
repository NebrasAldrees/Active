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
        public virtual async Task<tblKFUuser> GetKFUuserByUsername(string Username)
        {
            return await dbSet.Where(user => user.IsDeleted == false && user.Username == Username)
                .SingleOrDefaultAsync();
        }
        public virtual async Task<tblKFUuser> CheckUser(String username, String password)
        {
            return await dbSet.SingleOrDefaultAsync(user => user.Username == username && user.Password == password);
        }
        public virtual async Task<int> InsertKfuUser(tblKFUuser KFUuser)
        {
            try
            {
                await InsertAsync(KFUuser);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public virtual async Task<tblKFUuser> checkUser(string Username, string Password)
        {
            return await dbSet.Where(user => user.Username == Username && user.Password == Password).SingleOrDefaultAsync();

        }

    }
}
