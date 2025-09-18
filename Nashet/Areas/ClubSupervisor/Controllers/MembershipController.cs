using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.ClubSupervisor.Controllers
{
    public class MemberShipController
    {
        [Area("ClubSupervisor")]
        public class MembershipController : Controller
        {
            private readonly MembershipDomain _MembershipDomain;
            public MembershipController(MembershipDomain MembershipDomain)
            {
                _MembershipDomain = MembershipDomain;
            }
            public async Task<IActionResult> ViewMembers()
            {
                return View(await _MembershipDomain.GetMembership());
            }
            public async Task<IActionResult> InsertMembership()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> InsertMembership(MembershipViewModel viewModel)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        int check = await _MembershipDomain.InsertMembership(viewModel);
                        if (check == 1)
                            ViewData["Successful"] = "Successful";
                        else
                            ViewData["Failed"] = "Failed";
                    }
                    catch
                    {
                        ViewData["Failed"] = "Failed";
                    }
                }
                return View(viewModel);
            }
        }
    }
}

