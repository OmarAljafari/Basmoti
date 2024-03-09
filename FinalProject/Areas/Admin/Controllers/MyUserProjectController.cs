using FinalProject.Areas.Admin.ViewModels;
using FinalProject.Models;
using FinalProject.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MyUserProjectController : Controller
    {
     
        public UserManager<MyUserProject> _User { get; }

        public MyUserProjectController(UserManager<MyUserProject> user)
        {
            _User = user;
        }
        // GET: UserController
        public ActionResult Index()
        {
            IList<MyUserProject> list = _User.Users.Where(x => !x.IsDelete).ToList();
            return View(list);
        }


        public async Task<ActionResult> Active(string idActive)
        {
            //MyUserProject data = _User.Users.SingleOrDefault(data => data.Id == id);
            MyUserProject data = await _User.FindByIdAsync(idActive);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            data.IsActive = !data.IsActive;
            await _User.UpdateAsync(data);
            return RedirectToAction(nameof(Index));
        }
      

        // GET: UserController/Create
        public ActionResult Create()
        {
            Register obj = new Register();
            return View(obj);
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Register collection)
        {
            try
            {
                MyUserProject user = new MyUserProject()
                {
                    Email = collection.RegisterEmail,
                    UserName = collection.RegisterName,
                    IsActive = true,
                    IsDelete = false,
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };
                if (!ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(collection.RegisterEmail))
                    {
                        ModelState.AddModelError("", "Please Enter The Email");
                    }
                    if (string.IsNullOrEmpty(collection.RegisterPassword) )
                    {
                        ModelState.AddModelError("", "Please Enter The Password And Confirm It");
                    }
                    return View(collection);
                }
                var userExist = _User.Users.SingleOrDefault(u => u.UserName.ToUpper() == user.UserName.ToUpper());


                if (userExist != null && !string.IsNullOrEmpty(userExist.UserName))
                {
                    ModelState.AddModelError("", "This user is already exist");
                }

                if (userExist == null)
                {
                    
                    var Result = await _User.CreateAsync(user, collection.RegisterPassword);
                    if (Result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }

                return View(collection);
        
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(string id)
        {
            var data = _User.Users.SingleOrDefault(x => x.Id == id);

           
            return View(data);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Edit(string id, MyUserProject collection)
        {
            try
            {

                if (_User.Users.SingleOrDefault(x => x.Email.ToUpper() == collection.Email.ToUpper() && x.Id != collection.Id) != null)
                {
                    ModelState.AddModelError("", "This email is already exist");
                    return View(collection);
                }
                var data = await _User.FindByIdAsync(collection.Id);
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                data.EditDate = DateTime.Now;
                data.UserName = collection.UserName;
                data.Email = collection.Email;
                await _User.UpdateAsync(data);



                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public async Task <ActionResult> Delete(string idDelete)
        {

            var data = await _User.FindByIdAsync(idDelete);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _User.UpdateAsync(data);
            return RedirectToAction(nameof(Index));
        }

        
     
    }
}
