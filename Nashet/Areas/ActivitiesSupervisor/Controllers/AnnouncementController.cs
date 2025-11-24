using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;
using Nashet.Models;
using System;
using System.Diagnostics;

namespace Nashet.Areas.ActivitiesSupervisor.Controllers
{
    [Area("ActivitiesSupervisor")]
    [Authorize(Roles = "ActivitySupervisor")]

    public class AnnouncementController : Controller
    {
        private readonly AnnouncementDomain _AnnouncementDomain;
        private readonly ClubDomain _ClubDomain;
        private readonly IWebHostEnvironment _webHost;

        public AnnouncementController(AnnouncementDomain announcementDomain, ClubDomain clubDomain, IWebHostEnvironment webHost)
        {
            _AnnouncementDomain = announcementDomain;
            _ClubDomain = clubDomain;
            _webHost = webHost;
        }
        [HttpGet]
        public async Task<IActionResult> ViewAnnouncement()
        {
            return View(await _AnnouncementDomain.GetAnnouncement());
        }
        [HttpGet]
        public async Task<IActionResult> AnnouncementPage(Guid id)
        {
            try
            {
                var announcement = await _AnnouncementDomain.GetAnnouncementByGuid(id);
                if (announcement == null)
                {
                    return NotFound();
                }

                var clubList = await _ClubDomain.GetClub();
                var currentClub = clubList.FirstOrDefault(c => c.ClubId == announcement.ClubId);
                ViewBag.currentClub = currentClub;

                return View(announcement);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
        
        public async Task<IActionResult> InsertAnnouncement()
        {
            ViewBag.Club = await _ClubDomain.GetClub();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertAnnouncement(AnnouncementViewModel viewModel, Microsoft.AspNetCore.Http.IFormFile AnnouncementImage)
        {
            ViewBag.Club = await _ClubDomain.GetClub();
            if (ModelState.IsValid)
            {
                try
                {
                    if (AnnouncementImage != null && AnnouncementImage.Length > 0)
                    {
                        string uploadFolder = Path.Combine(_webHost.WebRootPath, "uploads");

                        if (!Directory.Exists(uploadFolder))
                        {
                            Directory.CreateDirectory(uploadFolder);
                        }

                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(AnnouncementImage.FileName);
                        string fileSavePath = Path.Combine(uploadFolder, fileName);

                        using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                        {
                            await AnnouncementImage.CopyToAsync(stream);
                        }

                        viewModel.AnnouncementImage = "/uploads/" + fileName;
                        ViewBag.Message = " تم الرفع بنجاح";
                    }

                    int check = await _AnnouncementDomain.InsertAnnouncement(viewModel);
                    if (check == 1)
                    {
                        ViewBag.Successful = "تم إضافة الإعلان بنجاح";
                        return View(viewModel);
                    }

                    else if (check == -1)
                        ViewBag.Duplicate = "اسم الإعلان موجود مسبقاً";
                    else
                        ViewBag.Error = "فشل في الإضافة";

                }
                catch (Exception ex)
                {
                    ViewBag.Error = "فشل في الإضافة";
                }
            }


            return View(viewModel);
        }
        public async Task<IActionResult> UpdateAnnouncement(Guid guid)
        {
            try
            {
                var entity = await _AnnouncementDomain.GetAnnouncementByGuid(guid);
                if (entity == null)
                {
                    TempData["Error"] = "الإعلان غير موجود";
                    return RedirectToAction("ActivitiesSupervisorHome", "Home");
                }
                ViewBag.Club = await _ClubDomain.GetClub();

                var viewModel = new AnnouncementViewModel
                {
                    Guid = entity.Guid,
                    AnnouncementTopic = entity.AnnouncementTopic,
                    AnnouncementDetails = entity.AnnouncementDetails,
                    AnnouncementImage = entity.AnnouncementImage,
                    AnnouncementType = entity.AnnouncementType,
                    ClubGuid = entity.ClubGuid
                };
                ViewBag.Success = "تم تحديث بيانات الإعلان بنجاح";
                return View(viewModel);
            }
            catch
            {
                TempData["Error"] = "حدث خطأ أثناء التحديث";
                return RedirectToAction("ActivitiesSupervisorHome", "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAnnouncement(AnnouncementViewModel viewModel, Microsoft.AspNetCore.Http.IFormFile AnnouncementImage)
        {
            ViewBag.Club = await _ClubDomain.GetClub();

            if (ModelState.IsValid)
            {
                try
                {
                    if (AnnouncementImage != null && AnnouncementImage.Length > 0)
                    {
                        string uploadFolder = Path.Combine(_webHost.WebRootPath, "uploads");

                        if (!Directory.Exists(uploadFolder))
                        {
                            Directory.CreateDirectory(uploadFolder);
                        }

                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(AnnouncementImage.FileName);
                        string fileSavePath = Path.Combine(uploadFolder, fileName);

                        using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                        {
                            await AnnouncementImage.CopyToAsync(stream);
                        }

                        viewModel.AnnouncementImage = "/uploads/" + fileName;
                        ViewBag.Message = " تم الرفع بنجاح";
                    }

                    int check = await _AnnouncementDomain.UpdateAnnouncement(viewModel);
                    if (check == 1)
                    {
                        TempData["Success"] = "تم تحديث بيانات الإعلان بنجاح";
                        return RedirectToAction("ActivitiesSupervisorHome", "Home");
                    }

                    else if (check == -1)
                        ViewBag.Duplicate = "اسم الإعلان موجود مسبقاً";
                    else
                        ViewBag.Error = "فشل في التحديث";

                }
                catch (Exception ex)
                {
                    ViewBag.Error = "فشل في التحديث";
                }
            }
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAnnouncement(Guid guid)
        {
            try
            {
                var result = await _AnnouncementDomain.DeleteAnnouncement(guid);

                if (result)
                {
                    return Json(new { success = true, message = "تم الحذف بنجاح" });
                }
                else
                {
                    return Json(new { error = false, message = "فشل في الحذف" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = false, message = "حدث خطأ: " + ex.Message });
            }
        }
    }
}
