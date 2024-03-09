using FinalProject.Areas.Admin.ViewModels;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        public AccountController(SignInManager<MyUserProject> signInManager, UserManager<MyUserProject> userManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }

        public SignInManager<MyUserProject> SignInManager { get; }
        public UserManager<MyUserProject> UserManager { get; }

        [Authorize]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(Register collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Fill out all info");
                return View();
            }
            var obj = new MyUserProject
            {
                Email = collection.RegisterEmail,
                UserName = collection.RegisterName
            };
            if (collection.RegisterAccept == true)
            {
                var res = await UserManager.CreateAsync(obj, collection.RegisterPassword);
                if (res.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("",res.ToString() );
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "You must to accept the terms and conditions");
                return View();
            }
           
           

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Login(Login collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Fill out all info");
                return View();
            }
            var res = await SignInManager.PasswordSignInAsync(collection.LoginUserName, collection.LoginPassword, isPersistent: collection.RememberMe, false);
            if (res.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", res.ToString()+": The information is not right");
            return View();
        }


        public ActionResult Logout()
        {
            SignInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
