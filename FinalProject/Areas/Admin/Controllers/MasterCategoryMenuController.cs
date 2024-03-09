using FinalProject.Models;
using FinalProject.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.IO;
using System;
using System.Security.Claims;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterCategoryMenuController : Controller
    {
        public IRepository<MasterCategoryMenu> Mcm { get; }

        public MasterCategoryMenuController(IRepository<MasterCategoryMenu> mcm)
        {
            Mcm = mcm;
        }

        // GET: MasterCategoryMenuController
        public ActionResult Index()
        {
            return View(Mcm.View());
        }

      
     
        // GET: MasterCategoryMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterCategoryMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterCategoryMenu collection)
        {
            try
            {
                collection.CreateDate = DateTime.Now;
                collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.IsActive = true;
                Mcm.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterCategoryMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Mcm.Find(id));
        }

        // POST: MasterCategoryMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterCategoryMenu collection)
        {
            try
            {
                collection.EditDate = DateTime.Now;
                collection.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Mcm.Update(id,collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterCategoryMenuController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if(idDelete != 0)
            {
                var data = Mcm.Find(idDelete);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Mcm.Delete(idDelete,data);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Active(int idActive)
        {
            if (idActive != 0)
            {
                var data = Mcm.Find(idActive);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Mcm.Active(idActive, data);

            }
            return RedirectToAction(nameof(Index));

        }

    }
}

//< td class= "align-middle text-center" >
//    < a asp - action = "MasterMenuEdit" asp - route - id = "@item.MasterMenuId" >< i class= "fa-solid fa-pen-to-square fa-2xl" ></ i ></ a > |

//    < a href = "" class= "csBtnDelete" data - bs - toggle = "modal" data - bs - target = "#exampleModal"
//       data - path = "@Url.ActionLink("MasterMenuIndex", "Home", new { idDelete = item.MasterMenuId })">
//        <i class= "bx bxs-trash text-danger  fa-2xl " ></ i >
//    </ a >
//    @if(item.IsActive)
//    {
//        < a asp - action = "Active" asp - route - id = "@item.MasterMenuId" >
//            < i class= "ri-eye-fill text-success  fa-2xl" ></ i >
//        </ a >
//    }
//    else
//{
//        < a asp - action = "Active" asp - route - id = "@item.MasterMenuId" >
//            < i class= "ri-eye-close-fill text-danger  fa-2xl" ></ i >
//        </ a >
//    }
//</ td >