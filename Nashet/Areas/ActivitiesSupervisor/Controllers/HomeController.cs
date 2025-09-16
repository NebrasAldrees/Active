using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Data.Models;
using Nashet.Models;
using System.Diagnostics;

namespace Nashet.Areas.ActivitiesSupervisor.Controllers
{
    [Area("ActivitiesSupervisor")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserDomain _UserDomain;
        private readonly TeamDomain _TeamDomain;
        private readonly ActivityDomain _ActivityDomain;
        private readonly ActivityRequestDomain _ActivityRequestDomain;
        private readonly AnnouncementDomain _AnnouncementDomain;
        private readonly ClubDomain _ClubDomain;
        private readonly ReportDomain _ReportDomain;

        public int UserId { get; private set; }

        public HomeController(ILogger<HomeController> logger, UserDomain userDomain, TeamDomain teamDomain,
            ActivityDomain activityDomain, ActivityRequestDomain activityRequestDomain, AnnouncementDomain announcementDomain,
            ClubDomain clubDomain, ReportDomain reportDomain)
        {
            _logger = logger;
            _UserDomain = userDomain;
            _TeamDomain = teamDomain;
            _ActivityDomain = activityDomain;
            _ActivityRequestDomain = activityRequestDomain;
            _AnnouncementDomain = announcementDomain;
            _ClubDomain = clubDomain;
            _ReportDomain = reportDomain;
        }
<<<<<<< HEAD
<<<<<<< HEAD
        
        
        public IActionResult ActivitiesSupervisorHome()
        {
            return View();
        }
=======
=======
>>>>>>> 5da93367c7711c4edcd5cf0ec7e041a8627bd7c6
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Activities()
        {
            return View();
        }
        public IActionResult ActivitiesSupervisorHome()
        {
            return View();
        }
<<<<<<< HEAD
>>>>>>> 5da93367c7711c4edcd5cf0ec7e041a8627bd7c6
=======
>>>>>>> 5da93367c7711c4edcd5cf0ec7e041a8627bd7c6
        public IActionResult Clubs()
        {
            return View();
        }
        
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> 5da93367c7711c4edcd5cf0ec7e041a8627bd7c6
        public IActionResult InsertClub()
        {
            return View();
        }
        public IActionResult InsertActivity()
        {
            return View();
        }
        public IActionResult InsertAnnouncement()
        {
            return View();
        }
<<<<<<< HEAD
>>>>>>> 5da93367c7711c4edcd5cf0ec7e041a8627bd7c6
=======
>>>>>>> 5da93367c7711c4edcd5cf0ec7e041a8627bd7c6
        public IActionResult Requests()
        {
            return View();
        }
        
        public async Task<IActionResult> ViewUsers()
        {
            return View(await _UserDomain.GetUserByIdAsync(UserId));
        }
<<<<<<< HEAD
<<<<<<< HEAD
        
=======
        [HttpPost]
        [ValidateAntiForgeryToken]
>>>>>>> 5da93367c7711c4edcd5cf0ec7e041a8627bd7c6
=======
        [HttpPost]
        [ValidateAntiForgeryToken]
>>>>>>> 5da93367c7711c4edcd5cf0ec7e041a8627bd7c6

        public IActionResult InsertUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> ViewTeams()
        {
            return View(await _TeamDomain.GetTeam());
        }
<<<<<<< HEAD
<<<<<<< HEAD

        public IActionResult InsertAnnouncement()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
=======
=======
>>>>>>> 5da93367c7711c4edcd5cf0ec7e041a8627bd7c6
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> InsertActivity(tblActivity Activity)
        {
            try
            {
                int check = await _ActivityDomain.InsertActivity(Activity);
                if (check == 1)
                    ViewBag.Successful = "Successful";
                else
                    ViewBag.Failed = "Failed";
            }
            catch { }
            return View(Activity);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> ViewActivities()
        {
            return View(await _ActivityDomain.GetActivity());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]


<<<<<<< HEAD
>>>>>>> 5da93367c7711c4edcd5cf0ec7e041a8627bd7c6
=======
>>>>>>> 5da93367c7711c4edcd5cf0ec7e041a8627bd7c6
        public async Task<IActionResult> InsertAnnouncement(tblAnnouncement Announcement)
        {
            try
            {
                int check = await _AnnouncementDomain.InsertAnnouncement(Announcement);
                if (check == 1)
                    ViewBag.Successful = "Successful";
                else
                    ViewBag.Failed = "Failed";
            }
            catch { }
            return View(Announcement);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> ViewAnnouncements()
        {
            return View(await _AnnouncementDomain.GetAnnouncement());
        }
<<<<<<< HEAD
<<<<<<< HEAD

        public IActionResult InsertClub()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
=======
=======
>>>>>>> 5da93367c7711c4edcd5cf0ec7e041a8627bd7c6
        [HttpPost]
        [ValidateAntiForgeryToken]


<<<<<<< HEAD
>>>>>>> 5da93367c7711c4edcd5cf0ec7e041a8627bd7c6
=======
>>>>>>> 5da93367c7711c4edcd5cf0ec7e041a8627bd7c6
        public async Task<IActionResult> InsertClub(tblClub Club)
        {
            try
            {
                int check = await _ClubDomain.InsertClub(Club);
                if (check == 1)
                    ViewBag.Successful = "Successful";
                else
                    ViewBag.Failed = "Failed";
            }
            catch { }
            return View(Club);
        }
<<<<<<< HEAD
<<<<<<< HEAD
=======
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
>>>>>>> 5da93367c7711c4edcd5cf0ec7e041a8627bd7c6
=======
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
>>>>>>> 5da93367c7711c4edcd5cf0ec7e041a8627bd7c6
        public async Task<IActionResult> ViewClubs()
        {
            return View(await _ClubDomain.GetClub());
        }
<<<<<<< HEAD
<<<<<<< HEAD
        
=======
        [HttpPost]
        [ValidateAntiForgeryToken]
>>>>>>> 5da93367c7711c4edcd5cf0ec7e041a8627bd7c6
=======
        [HttpPost]
        [ValidateAntiForgeryToken]
>>>>>>> 5da93367c7711c4edcd5cf0ec7e041a8627bd7c6
        //public async Task<IActionResult> Requests()
        //{
        //    return View(await _ActivityRequestDomain.GetActivityRequest());
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
<<<<<<< HEAD
<<<<<<< HEAD
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
=======

>>>>>>> 5da93367c7711c4edcd5cf0ec7e041a8627bd7c6
=======

>>>>>>> 5da93367c7711c4edcd5cf0ec7e041a8627bd7c6
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
