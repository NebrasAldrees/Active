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
    public class SystemLogsRepository : BaseRepository<tblSystemLogs>
    {
        public SystemLogsRepository(NashetContext dbContext) : base(dbContext)
        {
        }
        public virtual async Task<int> InsertLog(tblSystemLogs Log)
        {
            try
            {
                await InsertAsync(Log);
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
