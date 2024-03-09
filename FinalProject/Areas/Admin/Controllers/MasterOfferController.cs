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
    [Authorize]
    [Area("Admin")]
    public class MasterOfferController : Controller
    {
        public IRepository<MasterOffer> MasterOffer { get; }
        public IHostingEnvironment Host { get; }

        public MasterOfferController(IRepository<MasterOffer> masterOffer,IHostingEnvironment host)
        {
            MasterOffer = masterOffer;
            Host = host;
        }

        // GET: MasterOfferController
        public ActionResult Index()
        {
            return View(MasterOffer.View());
        }


        // GET: MasterOfferController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterOfferController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterOfferViewModel collection)
        {
            try
            {
                var data = new MasterOffer
                {
                    MasterOfferBreef = collection.MasterOfferBreef,
                    MasterOfferDesc = collection.MasterOfferDesc,
                    MasterOfferId = collection.MasterOfferId,
                    MasterOfferTitle = collection.MasterOfferTitle,
                    MasterOfferImageUrl = UploadImage(collection.file),
                    IsActive = true,
                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier)

                };
                MasterOffer.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterOfferController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterOffer.Find(id);
            MasterOfferViewModel obj = new MasterOfferViewModel
            {
                MasterOfferBreef = data.MasterOfferBreef,   
                MasterOfferDesc = data.MasterOfferDesc,
                MasterOfferId = data.MasterOfferId,
                MasterOfferTitle = data.MasterOfferTitle,
                MasterOfferImageUrl = data.MasterOfferImageUrl,
               

            };
            return View(obj);
        }

        // POST: MasterOfferController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterOfferViewModel collection)
        {
            try
            {
                var data = MasterOffer.Find(id);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                data.MasterOfferDesc = collection.MasterOfferDesc;
                data.MasterOfferBreef = collection.MasterOfferBreef;
                data.MasterOfferTitle = collection.MasterOfferTitle;
                data.MasterOfferId = collection.MasterOfferId;
                data.MasterOfferImageUrl = (collection.file !=null)?UploadImage(collection.file):collection.MasterOfferImageUrl;
                MasterOffer.Update(id,data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterOfferController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if (idDelete != 0)
            {
                var data = MasterOffer.Find(idDelete);
                data.EditDate= DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                MasterOffer.Delete(idDelete,data);

            }
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Active(int idActive)
        {
            if(idActive != 0)
            {
                var data =MasterOffer.Find(idActive);
                data.EditDate= DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                MasterOffer.Active(idActive,data);
            }
            return RedirectToAction(nameof(Index));
        }
       

        public string UploadImage(IFormFile file)
        {
            string image = "";
            if(file != null)
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
