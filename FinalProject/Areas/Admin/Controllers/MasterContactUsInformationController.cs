using FinalProject.Areas.Admin.ViewModels;
using FinalProject.Models;
using FinalProject.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterContactUsInformationController : Controller
    {
        public IRepository<MasterContactUsInformation> Mcui { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterContactUsInformationController(IRepository<MasterContactUsInformation> mcui, Microsoft.AspNetCore.Hosting.IHostingEnvironment host)
        {
            Mcui = mcui;
            Host = host;
        }

        // GET: MasterContactUsInformationController
        public ActionResult Index()
        {
            return View(Mcui.View());
        }


        // GET: MasterContactUsInformationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterContactUsInformationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterContactUsInformation collection)
        {
            try
            {
                
               collection.CreateDate = DateTime.Now;
               collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
               collection.IsActive = true;
                Mcui.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterContactUsInformationController/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(Mcui.Find(id));
        }

        // POST: MasterContactUsInformationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterContactUsInformation collection)
        {
            try
            {
               
                var data = Mcui.Find(id);
                data.CreateUser = collection.CreateUser;
                data.CreateDate = collection.CreateDate;
                data.IsActive = collection.IsActive;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                data.EditDate = DateTime.Now;
                data.MasterContactUsInformationIdesc = collection.MasterContactUsInformationIdesc;
                data.MasterContactUsInformationRedirect = collection.MasterContactUsInformationRedirect;
                data.MasterContactUsInformationImageUrl = collection.MasterContactUsInformationImageUrl;
                Mcui.Update(id,data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterContactUsInformationController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if(idDelete > 0)
            {
                var data = Mcui.Find(idDelete);
                data.IsDelete = true;
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Mcui.Update(idDelete,data);
            }
            return RedirectToAction("Index");
        }


        public string UploadImage(IFormFile file)
        {
            string image = "";
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

        public ActionResult Active(int idActive)
        {
            if (idActive != 0)
            {
                var data = Mcui.Find(idActive);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Mcui.Active(idActive, data);

            }
            return RedirectToAction(nameof(Index));

        }
    }
}
