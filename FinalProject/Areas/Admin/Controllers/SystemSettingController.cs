using FinalProject.Areas.Admin.ViewModels;
using FinalProject.Models;
using FinalProject.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SystemSettingController : Controller
    {
        public IRepository<SystemSetting> SystemSetting { get; }
        public IHostingEnvironment Host { get; }

        public SystemSettingController(IRepository<SystemSetting> systemSetting,IHostingEnvironment host)
        {
            SystemSetting = systemSetting;
            Host = host;
        }
        // GET: SystemSettingController
        public ActionResult Index()
        {
            return View(SystemSetting.View());
        }

       

        // GET: SystemSettingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemSettingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SystemSettingViewModel collection)
        {
            try
            {
                var data = new SystemSetting
                {
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    SystemSettingId = collection.SystemSettingId,
                    SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle,
                    SystemSettingMapLocation = collection.SystemSettingMapLocation,
                    SystemSettingWelcomeNoteUrl = collection.SystemSettingWelcomeNoteUrl,
                    SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                    SystemSettingLogoImageUrl = UploadImage(collection.FileLogo1),
                    SystemSettingLogoImageUrl2 = UploadImage(collection.FileLogo2),
                    SystemSettingWelcomeNoteImageUrl = UploadImage(collection.FileNote),
                    IsActive = true,
                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier)

                };
                SystemSetting.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = SystemSetting.Find(id); 
            SystemSettingViewModel obj = new SystemSettingViewModel
            {
                SystemSettingMapLocation = data.SystemSettingMapLocation,
                SystemSettingCopyright = data.SystemSettingCopyright,
                SystemSettingId = data.SystemSettingId,
                SystemSettingWelcomeNoteBreef = data.SystemSettingWelcomeNoteBreef,
                SystemSettingWelcomeNoteDesc = data.SystemSettingWelcomeNoteDesc,
                SystemSettingWelcomeNoteTitle = data.SystemSettingWelcomeNoteTitle,
                SystemSettingWelcomeNoteUrl = data.SystemSettingWelcomeNoteUrl,
                SystemSettingLogoImageUrl = data.SystemSettingLogoImageUrl,
                SystemSettingLogoImageUrl2 = data.SystemSettingLogoImageUrl2,
                SystemSettingWelcomeNoteImageUrl = data.SystemSettingWelcomeNoteImageUrl,
                IsActive = data.IsActive,
                CreateDate = data.CreateDate,
                CreateUser = data.CreateUser
            };
            return View(obj);
        }

        // POST: SystemSettingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SystemSettingViewModel collection)
        {
            try
            {
                var data = new SystemSetting
                {
                    SystemSettingMapLocation = collection.SystemSettingMapLocation,
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    SystemSettingId = collection.SystemSettingId,
                    SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteTitle=collection.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteUrl  =collection.SystemSettingWelcomeNoteUrl,
                    SystemSettingLogoImageUrl=(collection.FileLogo1 !=null)? UploadImage(collection.FileLogo1):collection.SystemSettingLogoImageUrl,
                    SystemSettingLogoImageUrl2 =(collection.FileLogo2 !=null)? UploadImage(collection.FileLogo2):collection.SystemSettingLogoImageUrl2,
                    SystemSettingWelcomeNoteImageUrl = (collection.FileNote != null) ? UploadImage(collection.FileNote) : collection.SystemSettingWelcomeNoteImageUrl,
                    IsActive = collection.IsActive,
                    CreateDate = collection.CreateDate,
                    CreateUser = collection.CreateUser,
                    EditDate = DateTime.Now,  
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                };
                SystemSetting.Update(id,data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if (idDelete > 0)
            {
                var data = SystemSetting.Find(idDelete);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                SystemSetting.Delete(idDelete,data);
            }
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Active(int idActive)
        {
            if (idActive != 0)
            {
                var data = SystemSetting.Find(idActive);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                SystemSetting.Active(idActive, data);
            }
            return RedirectToAction(nameof(Index));
        }



       public string UploadImage(IFormFile file)
        {
            var image = "";
            if (file != null)
            {
                string path = Path.Combine(Host.WebRootPath,"Img");
                FileInfo info = new FileInfo(file.FileName);
                image = "Img"+Guid.NewGuid()+info.Extension;
                string FullPath = Path.Combine(path,image);
                file.CopyTo(new FileStream(FullPath,FileMode.Create));
            }

            return image;
        }
    }
}
