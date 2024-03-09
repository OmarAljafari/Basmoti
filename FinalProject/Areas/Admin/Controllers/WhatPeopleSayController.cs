using FinalProject.Areas.Admin.ViewModels;
using FinalProject.Models;
using FinalProject.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class WhatPeopleSayController : Controller
    {
        public IRepository<WhatPeopleSay> WhatPeopleSay { get; }
        public IHostingEnvironment Host { get; }

        public WhatPeopleSayController(IRepository<WhatPeopleSay> _WhatPeopleSay, IHostingEnvironment host)
        {
            WhatPeopleSay = _WhatPeopleSay;
            Host = host;
        }
      
        // GET: WhatPeopleSayController
        public ActionResult Index()
        {
            return View(WhatPeopleSay.View());
        }

        
        // GET: WhatPeopleSayController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WhatPeopleSayController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WhatPeopleSayViewModel collection)
        {
            try
            {
                var data = new WhatPeopleSay
                {
                    WhatPeopleSayId = collection.WhatPeopleSayId,
                    WhatPeopleSayDescription = collection.WhatPeopleSayDescription,
                    WhatPeopleSayName = collection.WhatPeopleSayName,
                    WhatPeopleSayTitle = collection.WhatPeopleSayTitle,
                    IsActive = true,
                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    WhatPeopleSayImage = UploadImage(collection.file),

                };

                WhatPeopleSay.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WhatPeopleSayController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = WhatPeopleSay.Find(id);
            var obj = new WhatPeopleSayViewModel
            {
                WhatPeopleSayId = data.WhatPeopleSayId,
                WhatPeopleSayDescription = data.WhatPeopleSayDescription,
                WhatPeopleSayName= data.WhatPeopleSayName,
                WhatPeopleSayTitle= data.WhatPeopleSayTitle,
                WhatPeopleSayImage = data.WhatPeopleSayImage,
            };
            return View(obj);
        }

        // POST: WhatPeopleSayController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WhatPeopleSayViewModel collection)
        {
            try
            {
                var data = WhatPeopleSay.Find(collection.WhatPeopleSayId);
                data.WhatPeopleSayDescription = collection.WhatPeopleSayDescription;
                data.WhatPeopleSayTitle = collection.WhatPeopleSayTitle;
                data.WhatPeopleSayName = collection.WhatPeopleSayName;
                data.WhatPeopleSayImage = (collection.file != null) ? UploadImage(collection.file) : data.WhatPeopleSayImage;
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                WhatPeopleSay.Update(id,data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WhatPeopleSayController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if (idDelete != 0)
            {
                var data = WhatPeopleSay.Find(idDelete);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                WhatPeopleSay.Delete(idDelete,data);

            }
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Active(int idActive)
        {
            if(idActive != 0)
            {
                var data = WhatPeopleSay.Find(idActive);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                WhatPeopleSay.Active(idActive,data);
            }

            return RedirectToAction(nameof(Index));

        }


        public string UploadImage(IFormFile file)
        {
            var image = "";
            if(file != null)
            {
                string path = Path.Combine(Host.WebRootPath,"Img");
                FileInfo fileInfo = new FileInfo(file.FileName);
                image = "Img"+Guid.NewGuid()+fileInfo.Extension;
                string FullPath = Path.Combine(path,image);
                file.CopyTo(new FileStream(FullPath,FileMode.Create));

            }
            return image;

        }
    }
}
