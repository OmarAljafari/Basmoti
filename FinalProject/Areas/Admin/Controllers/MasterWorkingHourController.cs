using FinalProject.Models;
using FinalProject.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalProject.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]

    public class MasterWorkingHourController : Controller
    {
        public IRepository<MasterWorkingHour> Mwh { get; }

        public MasterWorkingHourController(IRepository<MasterWorkingHour> mwh)
        {
            Mwh = mwh;
        }

        // GET: MasterWorkingHourController
        public ActionResult Index()
        {
            return View(Mwh.View());
        }

       
        // GET: MasterWorkingHourController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterWorkingHourController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterWorkingHour collection)
        {
            try
            {
                collection.CreateDate = DateTime.Now;
                collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.IsActive = true;
                Mwh.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWorkingHourController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Mwh.Find(id));
        }

        // POST: MasterWorkingHourController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterWorkingHour collection)
        {
            try
            {
                collection.EditDate = DateTime.Now;
                collection.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Mwh.Update(id,collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWorkingHourController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if (idDelete > 0)
            {
                var data =Mwh.Find(idDelete);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Mwh.Delete(idDelete,data);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Active(int idActive)
        {
             if (idActive != 0)
            {
                var data = Mwh.Find(idActive);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Mwh.Active(idActive,data);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
