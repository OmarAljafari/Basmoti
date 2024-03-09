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
    
    public class MasterItemMenuController : Controller
    {
        public IRepository<MasterItemMenu> Mim { get; }
        public IRepository<MasterCategoryMenu> Mcm { get; }
        public IHostingEnvironment Host { get; }

        public MasterItemMenuController(IRepository<MasterItemMenu> mim,IRepository<MasterCategoryMenu> mcm,IHostingEnvironment host)
        {
            Mim = mim;
            Mcm = mcm;
            Host = host;
        }

        // GET: MasterItemMenuController
        public ActionResult Index()
        {
            return View(Mim.View());
        }

       

        // GET: MasterItemMenuController/Create
        public ActionResult Create()
        {
            ViewBag.MasterCategoryMenuList = Mcm.View();

            return View();
        }

        // POST: MasterItemMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterItemMenuViewModel collection)
        {
            try
            {

                MasterItemMenu obj = new MasterItemMenu
                {
                    MasterItemMenuId = collection.MasterItemMenuId,
                    MasterItemMenuBreef = collection.MasterItemMenuBreef,
                    MasterItemMenuDate = collection.MasterItemMenuDate,
                    MasterItemMenuPrice = collection.MasterItemMenuPrice,
                    MasterItemMenuTitle = collection.MasterItemMenuTitle,
                    MasterItemMenuDesc = collection.MasterItemMenuDesc,
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                    MasterItemMenuImageUrl = UploadImage(collection.file),
                    IsActive = true,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CreateDate = DateTime.Now,
                   
                };
               Mim.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterItemMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.MasterCategoryMenuList = Mcm.View();
            var obj = Mim.Find(id);
            MasterItemMenuViewModel data = new MasterItemMenuViewModel
            {
                MasterItemMenuId = obj.MasterItemMenuId,
                MasterCategoryMenuId = obj.MasterCategoryMenuId,
                MasterItemMenuBreef = obj.MasterItemMenuBreef,
                MasterItemMenuDate = obj.MasterItemMenuDate,
                MasterItemMenuDesc=obj.MasterItemMenuDesc,
                MasterItemMenuImageUrl=obj.MasterItemMenuImageUrl,
                MasterItemMenuPrice=obj.MasterItemMenuPrice,
                MasterItemMenuTitle=obj.MasterItemMenuTitle,
                IsActive = obj.IsActive,
                IsDelete = obj.IsDelete,
                CreateDate = obj.CreateDate,
                CreateUser = obj.CreateUser,
                EditDate = obj.EditDate,
                EditUser = obj.EditUser,
            };
            return View(data);
        }

        // POST: MasterItemMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterItemMenuViewModel collection)
        {
            try
            {
                var obj = new MasterItemMenu
                {
                    MasterItemMenuId = collection.MasterItemMenuId,
                    MasterItemMenuBreef = collection.MasterItemMenuBreef,
                    MasterItemMenuDate = collection.MasterItemMenuDate,
                    MasterItemMenuPrice = collection.MasterItemMenuPrice,
                    MasterItemMenuTitle = collection.MasterItemMenuTitle,
                    MasterItemMenuDesc = collection.MasterItemMenuDesc,
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                    MasterItemMenuImageUrl = (collection.file != null)?UploadImage(collection.file):collection.MasterItemMenuImageUrl ,
                    IsActive = collection.IsActive,
                    CreateUser = collection.CreateUser,
                    CreateDate = collection.CreateDate,
                    EditDate = DateTime.Now,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };
                Mim.Update(id,obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterItemMenuController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if (idDelete > 0)
            {
                var data = Mim.Find(idDelete);
                data.IsDelete = true;
                data.IsActive = false;
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Mim.Update(idDelete,data);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

       

        public string UploadImage(IFormFile file)
        {
            string image ="";
            if (file != null) 
            {
                string path = Path.Combine(Host.WebRootPath,"Img");
                FileInfo info = new FileInfo(file.FileName);
                image = "Img" + Guid.NewGuid() + info.Extension;
                string FullPath = Path.Combine(path, image);
                file.CopyTo(new FileStream(FullPath,FileMode.Create));
            }

            return image;
        }

        public ActionResult Active(int idActive)
        {
            if(idActive > 0)
            {
                var data = Mim.Find(idActive);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Mim.Active(idActive,data);
               
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
