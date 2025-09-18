using Nashet.Business.Domain.Common;
using Nashet.Business.ViewModels;
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

        public async Task<IList<ActivityViewModel>> GetActivity()
        {
            return _ActivityRepository.GetAllActivities().Result.Select(a => new ActivityViewModel
            {
                ActivityId = a.ActivityId,
                ClubId = a.ClubId,
                ActivityTopic = a.ActivityTopic,
                ActivityDescription = a.ActivityDescription,
                ActivityStartDate = a.ActivityStartDate,
                ActivityEndDate = a.ActivityEndDate,
                ActivityTime = a.ActivityTime,
                ActivityLocation = a.ActivityLocation,
                ActivityPoster = a.ActivityPoster,
                Guid = a.Guid
            }).ToList();
        }
        public virtual async Task<int> InsertActivity(ActivityViewModel viewModel)
        {
            try
            {
                tblActivity activity = new tblActivity
                {
                    ClubId = viewModel.ClubId,
                    ActivityTopic = viewModel.ActivityTopic,
                    ActivityDescription = viewModel.ActivityDescription,
                    ActivityStartDate = viewModel.ActivityStartDate,
                    ActivityEndDate = viewModel.ActivityEndDate,
                    ActivityTime = viewModel.ActivityTime,
                    ActivityLocation = viewModel.ActivityLocation,
                    ActivityPoster = viewModel.ActivityPoster,
                    Guid = viewModel.Guid
                };
                int check = await _ActivityRepository.InsertActivity(activity);
                if (check == 0)
                    return 0;
                else
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
