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
        private readonly ActivityRequestDomain _ActivityRequestDomain;
        private readonly AnnouncementDomain _AnnouncementDomain;
        private readonly ClubDomain _ClubDomain;
        private readonly ReportDomain _ReportDomain;

        public int UserId { get; private set; }

        public HomeController(ILogger<HomeController> logger, UserDomain userDomain, TeamDomain teamDomain,
            ActivityRequestDomain activityRequestDomain, AnnouncementDomain announcementDomain,
            ClubDomain clubDomain, ReportDomain reportDomain)
        {
            _logger = logger;
            _UserDomain = userDomain;
            _TeamDomain = teamDomain;
            _ActivityRequestDomain = activityRequestDomain;
            _AnnouncementDomain = announcementDomain;
            _ClubDomain = clubDomain;
            _ReportDomain = reportDomain;
        }
        
        
        public IActionResult ActivitiesSupervisorHome()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        
        
        public IActionResult Clubs()
        {
            return View();
        }
        
        public IActionResult InsertClub()
        {
            return View();
        }
        
        
        
        public async Task<IActionResult> ViewUsers()
        {
            return View(await _UserDomain.GetUserByIdAsync(UserId));
        }
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

        public async Task<IActionResult> ViewClubs()
        {
            return View(await _ClubDomain.GetClub());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
