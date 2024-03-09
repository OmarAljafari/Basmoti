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
    public class MasterServiceController : Controller
    {
        public IRepository<MasterService> MasterService { get; }
        public IHostingEnvironment Host { get; }

        public MasterServiceController(IRepository<MasterService> masterService,IHostingEnvironment host)
        {
            MasterService = masterService;
            Host = host;
        }
        // GET: MasterServiceController
        public ActionResult Index()
        {
            return View(MasterService.View());
        }

        
        // GET: MasterServiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterService collection)
        {
            try
            {
                collection.CreateDate = DateTime.Now;
                collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.IsActive = true;
                MasterService.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterServiceController/Edit/5
        public ActionResult Edit(int id)
        {
            
           
            return View(MasterService.Find(id));
        }

        // POST: MasterServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterService collection)
        {
            try
            {
                var data =MasterService.Find(id);
                data.MasterServiceTitle= collection.MasterServiceTitle;
                data.MasterServiceDesc= collection.MasterServiceDesc;
                data.MasterServiceId= collection.MasterServiceId;
                data.MasterServiceImage = collection.MasterServiceImage;
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                MasterService.Update(id,data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterServiceController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if(idDelete != 0)
            {
               var data= MasterService.Find(idDelete);
                data.EditDate= DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                MasterService.Delete(idDelete,data);
            }
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Active(int idActive)
        {
            if (idActive != 0)
            {
                var data = MasterService.Find(idActive); 
                data.EditDate= DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                MasterService.Active(idActive,data);
            }
            return RedirectToAction(nameof(Index));
        }


       public string UploadImage(IFormFile file)
        {
            var image = "";
            if(file != null)
            {
                string path = Path.Combine(Host.WebRootPath,"Img");
                FileInfo info = new FileInfo(file.FileName);
                image = "Img" + Guid.NewGuid() + info.Extension;
                string FullPath = Path.Combine(path, image);
                file.CopyTo(new FileStream(FullPath,FileMode.Create));
            }
            return image;
        }
    }
}
