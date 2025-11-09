using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;

namespace Nashet.Areas.ClubSupervisor.Controllers
{
    [Area("ClubSupervisor")]
    public class ActivityRequestController : Controller
    {
        private readonly ActivityDomain _ActivityDomain;
        private readonly ClubDomain _ClubDomain;
        public ActivityRequestController(ActivityDomain activityDomain, ClubDomain clubDomain)
        {
            _ActivityDomain = activityDomain;
            _ClubDomain = clubDomain;
        }
    }
}
