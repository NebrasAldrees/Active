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
        public async Task<tblActivity> GetActivityById(int id)
        {
            var Activity = await _ActivityRepository.GetActivityById(id);

            if (Activity == null)
            {
                throw new KeyNotFoundException($"Activity requested with ID {id} was not found.");
            }

            return Activity;
        }
        public int DeleteActivity(int id)
        {
            try
            {
                _ActivityRepository.Delete(id);
                return 1;
            }
            catch
            {
                return 0;
            }
        }



    }
}
