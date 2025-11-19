using Microsoft.EntityFrameworkCore;
using Nashet.Business.Domain.Common;
using Nashet.Business.ViewModels;
using Nashet.Data.Models;
using Nashet.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.Domain
{
    public class ActivityRequestDomain: BaseDomain
    {
        private readonly ActivityRequestRepository _ActivityRequestRepository;
        private readonly ClubRepository _ClubRepository;

        public ActivityRequestDomain(ActivityRequestRepository activityRequestRepository, ClubRepository ClubRepository)
        {
            _ActivityRequestRepository = activityRequestRepository;
            _ClubRepository = ClubRepository;
        }
        
        public async Task<IList<ActivityRequestViewModel>> GetActivityRequests()
        {
            

            return _ActivityRequestRepository.GetAllRequests().Result.Select(a => new ActivityRequestViewModel
            {
                ActivityRequestId = a.ActivityRequestId,
                ClubId = a.ClubId,
                ActivityTopic = a.ActivityTopic,
                ActivityDescription = a.ActivityDescription,
                ActivityStartDate = a.ActivityStartDate,
                ActivityEndDate = a.ActivityEndDate,
                ActivityLocation = a.ActivityLocation,
                ActivityPoster = a.ActivityPoster,
                StatusId = a.StatusId,
                Guid = a.Guid
            }).ToList();
        }
        public async Task<IList<ActivityRequestViewModel>> GetRequestsByClubGuid(Guid? clubGuid)
        {
            var requests = await GetActivityRequests();

            if (clubGuid.HasValue)
            {
                var club = await _ClubRepository.GetClubByGuid(clubGuid.Value);
                var clubId = club.ClubId;

                return requests.Where(a => a.ClubId == clubId).ToList();
            }

            return requests;
        }

        public async Task<tblActivityRequest> GetRequestByGuid(Guid guid)
        {
            var Request = await _ActivityRequestRepository.GetRequestByGUID(guid);

            if (Request == null)
            {
                throw new KeyNotFoundException($"بيانات الطلب المطلوب غير متوفرة");
            }

            return Request;
        }

        public virtual async Task<int> InsertActivityRequest(ActivityRequestViewModel viewModel)
        {
            try
            {
                DateTime.TryParse($"{viewModel.ActivityStartDate:yyyy-MM-dd} {viewModel.ActivityStartTime}", out var startDateTime);
                DateTime.TryParse($"{viewModel.ActivityEndDate:yyyy-MM-dd} {viewModel.ActivityEndTime}", out var endDateTime);
                var club = await _ClubRepository.GetClubByGuid(viewModel.ClubGuid);
                tblActivityRequest activity = new tblActivityRequest
                {
                    ClubId = club.ClubId,
                    StatusId = 1,
                    ActivityTopic = viewModel.ActivityTopic,
                    ActivityDescription = viewModel.ActivityDescription,
                    ActivityStartDate = startDateTime,
                    ActivityEndDate = endDateTime,
                    ActivityLocation = viewModel.ActivityLocation,
                    ActivityPoster = viewModel.ActivityPoster
                };
                int check = await _ActivityRequestRepository.InsertActivityRequest(activity);
                if (check == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }


            }
            catch
            {
                return 0;
            }
        }

        public virtual async Task<bool> UpdateActivityRequest(Guid guid)
        {
            try
            {
                var request = await _ActivityRequestRepository.GetRequestByGUID(guid);
                if (request == null)
                    return false;

                request.IsActive = false;
                request.StatusId = 2;
                await _ActivityRequestRepository.UpdateAsync(request);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public async Task<bool> DeleteActivityRequest(Guid guid)
        {
            try
            {
                var request = await _ActivityRequestRepository.GetRequestByGUID(guid);
                if (request == null)
                    return false;

                request.IsDeleted = true;
                request.StatusId = 3;
                await _ActivityRequestRepository.UpdateAsync(request);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
