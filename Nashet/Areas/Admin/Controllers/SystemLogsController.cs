using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;

namespace Nashet.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SystemLogsController : Controller
    {

        private readonly SystemLogsDomain _domain;
        public SystemLogsController(SystemLogsDomain domain)
        {
            _domain = domain;
        }
        public async Task<IActionResult> InsertLog(SystemLogsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int check = await _domain.InsertLog(viewModel);
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
