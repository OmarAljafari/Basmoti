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
    public class MasterSliderController : Controller
    {
        public IRepository<MasterSlider> MasterSlider { get; }
        public IHostingEnvironment Host { get; }

        public MasterSliderController(IRepository<MasterSlider> masterSlider,IHostingEnvironment host)
        {
            MasterSlider = masterSlider;
            Host = host;
        }
        // GET: MasterSliderController1cs
        public ActionResult Index()
        {
            return View(MasterSlider.View());
        }

        
        // GET: MasterSliderController1cs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSliderController1cs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSliderViewModel collection)
        {
            try
            {
                var data = new MasterSlider
                {
                    MasterSliderBreef = collection.MasterSliderBreef,
                    MasterSliderDesc = collection.MasterSliderDesc,
                    MasterSliderTitle = collection.MasterSliderTitle,
                    MasterSliderImg = UploadImage(collection.file),
                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive =true
                };
               
                MasterSlider.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSliderController1cs/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterSlider.Find(id);
            MasterSliderViewModel obj = new MasterSliderViewModel
            {
                MasterSliderBreef=data.MasterSliderBreef,
                MasterSliderDesc=data.MasterSliderDesc,
                MasterSliderId = data.MasterSliderId,
                MasterSliderTitle=data.MasterSliderTitle,
                MasterSliderImg = data.MasterSliderImg,
            };
            return View(obj);
        }

        // POST: MasterSliderController1cs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSliderViewModel collection)
        {
            try
            {
                var data = MasterSlider.Find(id);
                data.MasterSliderBreef = collection.MasterSliderBreef;
                data.MasterSliderTitle = collection.MasterSliderTitle;
                data.MasterSliderDesc = collection.MasterSliderDesc;
                data.CreateDate = data.CreateDate;
                data.CreateUser = data.CreateUser;
                data.MasterSliderImg = (collection.file !=null)? UploadImage(collection.file) : data.MasterSliderImg;
                data.IsActive = data.IsActive;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                data.EditDate = DateTime.Now;
                MasterSlider.Update(id,data);
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSliderController1cs/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if (idDelete > 0)
            {
                var data = MasterSlider.Find(idDelete);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                MasterSlider.Delete(idDelete,data);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Active(int idActive)
        {
            if(idActive > 0)
            {
                var data = MasterSlider.Find(idActive);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                MasterSlider.Active(idActive,data);
            }
            return RedirectToAction(nameof(Index));

        }

        public string UploadImage(IFormFile file)
        {
            var image = "";
            if (file != null)
            {
                string path = Path.Combine(Host.WebRootPath, "Img");
                FileInfo Info = new FileInfo(file.FileName);
                image = "Img" + Guid.NewGuid() + Info.Extension;
                string FullPath = Path.Combine(path, image);
                file.CopyTo(new FileStream(FullPath, FileMode.Create));
            }


            return image;

        }

    }
}
