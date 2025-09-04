using Nashet.Business.Domain.Common;
using Nashet.Data.Models;
using Nashet.Data.Repository;
using Nashet.Data.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.Domain
{
    public class ActivityDomain(ActivityRepository Repository) : BaseDomain
    {
        private readonly ActivityRepository _ActivityRepository = Repository;

        public async Task<IList<tblActivity>> GetActivity()
        {
            return await _ActivityRepository.GetAllActivities();
        }
        public virtual async Task<int> InsertActivity(tblActivity activity)
        {
            try
            {
                await _ActivityRepository.InsertActivity(activity);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        


    }
}
