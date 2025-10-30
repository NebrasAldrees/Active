﻿using Microsoft.AspNetCore.Mvc;
using Nashet.Business.Domain;
using Nashet.Business.ViewModels;
using Nashet.Models;
using System.Diagnostics;

namespace Nashet.Areas.ActivitiesSupervisor.Controllers
{
    [Area("ActivitiesSupervisor")]
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
        public async Task<IActionResult> AnnouncementPage(Guid guid)
        {
            var Announcement = await _AnnouncementDomain.GetAnnouncementByGuid(guid);
            if (Announcement == null)
            {
                return NotFound();
            }

            var clubList = await _ClubDomain.GetClub();
            var currentClub = clubList.FirstOrDefault(c => c.ClubId == Announcement.ClubId);
            ViewBag.currentClub = currentClub;

            var viewModel = new AnnouncementViewModel
            {
                Guid = Announcement.Guid,
                AnnouncementTopic = Announcement.AnnouncementTopic,
                AnnouncementDetails = Announcement.AnnouncementDetails,
                AnnouncementImage = Announcement.AnnouncementImage,
                AnnouncementType = Announcement.AnnouncementType,
                ClubId = Announcement.ClubId
            };


            return View(viewModel);
        }

        public async Task<IActionResult> InsertAnnouncement()
        {
            ViewBag.Club = await _ClubDomain.GetClub();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertAnnouncement(AnnouncementViewModel viewModel, IFormFile AnnouncementImage)
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
                    ViewBag.Error = "الإعلان غير موجود";
                    return RedirectToAction(nameof(AnnouncementPage));
                }
                ViewBag.Club = await _ClubDomain.GetClub();

                var viewModel = new AnnouncementViewModel
                {
                    Guid = entity.Guid,
                    AnnouncementTopic = entity.AnnouncementTopic,
                    AnnouncementDetails = entity.AnnouncementDetails,
                    AnnouncementImage = entity.AnnouncementImage,
                    AnnouncementType = entity.AnnouncementType,
                    ClubId = entity.ClubId
                };
                TempData["Successful"] = "تم التحديث بنجاح";
                return View(viewModel);
            }
            catch
            {
                TempData["Error"] = "حدث خطأ أثناء التحديث";
                return RedirectToAction(nameof(AnnouncementPage));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAnnouncement(AnnouncementViewModel viewModel, IFormFile AnnouncementImage)
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
                        ViewBag.Successful = "تم تحديث بيانات الإعلان بنجاح";
                        return View(viewModel);
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
            var result = await _AnnouncementDomain.DeleteAnnouncement(guid);
            return Json(new { success = true });

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
