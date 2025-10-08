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
        public virtual async Task<tblSystemRole> GetSystemRoleByIdAsync(int id)
        {
            return await dbSet.Where(SR => SR.IsDeleted == false && SR.SystemRoleId == id)
                            .FirstOrDefaultAsync();
        }
        public virtual async Task<int> InsertSystemRole(tblSystemRole SystemRole)
        {
            try
            {
                await InsertAsync(SystemRole);
                return 1;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error inserting system:{ex.Message}");
                return 0;
            }
        }

       
        }
    }
    
    
