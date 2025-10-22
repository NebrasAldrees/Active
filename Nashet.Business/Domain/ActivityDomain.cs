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
                    ActivityLocation = viewModel.ActivityLocation,
                    ActivityPoster = viewModel.ActivityPoster
                };
                int check = await _ActivityRepository.InsertActivity(activity);
                if (check == 0)
                {
                    return 0;
                }
                else
                {
                    var systemLog = new tblSystemLogs
                    {
                        UserId = 23456,
                        username="najd",
                        RecordId=17,
                        Table="tblActivity",
                        operation_date=DateTime.Now,
                        operation_type="Insert",
                        OldValue=null,
                       // NewValue=
                    };
                   //await _SystemLogsRepository.InsertLog(systemLog);
                    return 1;
                }


            }
            catch
            {
                return 0;
            }
        }
        public async Task<tblActivity> GetActivityByGuid(Guid guid)
        {
            var Activity = await _ActivityRepository.GetActivityByGuid(guid);

            if (Activity == null)
            {
                throw new KeyNotFoundException($"Activity requested with GUID {guid} was not found.");
            }

            return Activity;
        }

        public virtual async Task<int> UpdateActivity( ActivityViewModel viewModel)
        {
            try
            {
                var activity = await _ActivityRepository.GetActivityByGuid(viewModel.Guid);
                if (activity == null)
                {
                    return 0; 
                }

                activity.ActivityTopic =viewModel.ActivityTopic;
                activity.ActivityDescription = viewModel.ActivityDescription;
                activity.ActivityLocation = viewModel.ActivityLocation; 
                activity.ActivityPoster = viewModel.ActivityPoster;
                activity.ActivityStartDate = viewModel.ActivityStartDate;
                activity.ActivityEndDate = viewModel.ActivityEndDate;

                int check = await _ActivityRepository.updateActivity(activity);
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


        public virtual async Task<int> DeleteActivity(Guid guid)
        {
            try
            {
                var activity = await _ActivityRepository.GetActivityByGuid(guid);
                if (activity == null)
                {
                    return 0; // Site not found
                }

                int check = await _ActivityRepository.DeleteActivity(activity);
                if (check == null)
                    return 0;
                else
                    return 1;

            }
            catch
            {
                return 0;
            }
        }



    }
}
