using FinalProject.Areas.Admin.ViewModels;
using FinalProject.Models;
using FinalProject.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Security.Claims;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterSocialMediaController : Controller
    {
        public IRepository<MasterSocialMedia> MasterSocialMedia { get; }
        public IHostingEnvironment Host { get; }

        public MasterSocialMediaController(IRepository<MasterSocialMedia> masterSocialMedia,IHostingEnvironment host)
        {
            MasterSocialMedia = masterSocialMedia;
            Host = host;
        }
        // GET: MasterSocialMediaController
        public ActionResult Index()
        {
            return View(MasterSocialMedia.View());
        }

       
        // GET: MasterSocialMediaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSocialMediaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSocialMedia collection)
        {
            try
            {
                collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.CreateDate = DateTime.Now;
                collection.IsActive = true;
                MasterSocialMedia.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediaController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterSocialMedia.Find(id);
           

            return View(data);
        }

        // POST: MasterSocialMediaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSocialMedia collection)
        {
            try
            {
                var data = new MasterSocialMedia
                {
                    MasterSocialMediaId = collection.MasterSocialMediaId,
                    MasterSocialMediaUrl = collection.MasterSocialMediaUrl,
                    MasterSocialMediaImageUrl =  collection.MasterSocialMediaImageUrl,
                    CreateDate = collection.CreateDate,
                    CreateUser = collection.CreateUser,
                    IsActive = collection.IsActive,
                    EditDate = DateTime.Now,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                };
                MasterSocialMedia.Update(id,data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediaController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if(idDelete > 0)
            {
                var data = MasterSocialMedia.Find(idDelete);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                MasterSocialMedia.Delete(idDelete,data);
            }
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Active(int idActive)
        {
            if (idActive !=0)
            {
                var data = MasterSocialMedia.Find(idActive);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                MasterSocialMedia.Active(idActive,data);
            }
            return RedirectToAction(nameof(Index));
        }

       

        public string UploadImage(IFormFile file)
        {
            var image = "";
            if(file != null) 
            {
                string path = Path.Combine(Host.WebRootPath,"Img");
                FileInfo Info = new FileInfo(file.FileName);
                image = "Img"+Guid.NewGuid()+Info.Extension;
                string FullPath = Path.Combine(path, image);
                file.CopyTo(new FileStream(FullPath,FileMode.Create));
            }
            

            return image;

        }
    }
}
