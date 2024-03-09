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
    public class MasterMenuController : Controller
    {
        public IRepository<MasterMenu> Mm { get; }

        public MasterMenuController(IRepository<MasterMenu> mm)
        {
            Mm = mm;
        }

        // GET: MasterMenuController
        public ActionResult Index()
        {
            return View(Mm.View());
        }


        // GET: MasterMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterMenu collection)
        {
            try
            {
                collection.CreateDate = DateTime.Now;
                collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.IsActive = true;
                Mm.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Mm.Find(id));
        }

        // POST: MasterMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterMenu collection)
        {
            try
            {
                collection.EditDate = DateTime.Now;
                collection.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Mm.Update(id,collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMenuController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if (idDelete !=0)
            {
                var data = Mm.Find(idDelete);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Mm.Delete(idDelete,data);
            }
            return RedirectToAction(nameof(Index));
        }

       public ActionResult Active(int idActive)
        {
            if(idActive != 0)
            {
                var data = Mm.Find(idActive);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Mm.Active(idActive,data);

            }
            return RedirectToAction(nameof(Index));

        }
    }
}
