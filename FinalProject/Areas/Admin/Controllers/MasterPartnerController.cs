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
    public class MasterPartnerController : Controller
    {
        public IRepository<MasterPartner> MasterPartner { get; }
        public IHostingEnvironment Host { get; }

        public MasterPartnerController(IRepository<MasterPartner> masterPartner,IHostingEnvironment host)
        {
            MasterPartner = masterPartner;
            Host = host;
        }
        // GET: MasterPartnerController
        public ActionResult Index()
        {
            return View(MasterPartner.View());
        }

       

        // GET: MasterPartnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterPartnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterPartnerViewModel collection)
        {
            try
            {
                var data = new MasterPartner();
                data.MasterPartnerName = collection.MasterPartnerName;
                data.MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl;
                data.MasterPartnerId = collection.MasterPartnerId;
                data.MasterPartnerLogoImageUrl = UploadImage(collection.file);
                data.CreateDate = DateTime.Now;
                data.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                data.IsActive = true;
                MasterPartner.Add(data);
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPartnerController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterPartner.Find(id);
            var obj = new MasterPartnerViewModel 
            {
                MasterPartnerId = data.MasterPartnerId,
                MasterPartnerLogoImageUrl = data.MasterPartnerLogoImageUrl,
                MasterPartnerName = data.MasterPartnerName,
                MasterPartnerWebsiteUrl = data.MasterPartnerWebsiteUrl,
            };
            return View(obj);
        }

        // POST: MasterPartnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterPartnerViewModel collection)
        {
            try
            {
                var data = MasterPartner.Find(id);
                data.MasterPartnerName = collection.MasterPartnerName;
                data.MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl;
                data.MasterPartnerId = collection.MasterPartnerId;
                data.MasterPartnerLogoImageUrl = (collection.file != null) ? UploadImage(collection.file) : collection.MasterPartnerLogoImageUrl;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                data.EditDate = DateTime.Now;
                MasterPartner.Update(id,data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPartnerController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if (idDelete > 0)
            {
                var obj = MasterPartner.Find(idDelete);
                obj.EditDate = DateTime.Now;
                obj.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                MasterPartner.Delete(idDelete,obj);
            }
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Active(int idActive)
        {
            if (idActive != 0)
            {
                var data = MasterPartner.Find(idActive);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                MasterPartner.Active(idActive, data);
            }
            return RedirectToAction(nameof(Index));
        }


       public string UploadImage(IFormFile file)
        {
            var image = "";
            if(file != null)
            {
                string path = Path.Combine(Host.WebRootPath, "Img");
                FileInfo fileInfo = new FileInfo(file.FileName);
                image = "Img"+Guid.NewGuid()+fileInfo.Extension;
                string FullPath = Path.Combine(path, image);
                file.CopyTo(new FileStream(FullPath,FileMode.Create));
            }
            return image;
        }
    }
}
