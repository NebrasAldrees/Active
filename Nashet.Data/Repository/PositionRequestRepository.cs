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
    public class PositionRequestRepository : BaseRepository<tblPositionRequest>
    {
        public PositionRequestRepository(NashetContext dbContext) : base(dbContext)
        {
        }
        public virtual async Task<IList<tblPositionRequest>> GetAllPositionRequest()
        {
            return await dbSet.Where(PositionRequest => PositionRequest.IsDeleted == false).ToListAsync(); 
        }

        public virtual async Task<tblPositionRequest> GetPositionRequestById(int id)
        {
            return await dbSet.Where(PositionRequest => PositionRequest.IsDeleted == false && PositionRequest.PRId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<tblPositionRequest> GetPositionRequestByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<int> InsertPositionRequest(tblPositionRequest positionRequest)
        {
            try
            {

                await dbSet.AddAsync(positionRequest);
                return 1;


            }
            catch
            {
                return 0;
            }
        }
    }
}
