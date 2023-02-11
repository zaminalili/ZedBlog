using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZedBlog.Entity.Entities;
using ZedBlog.Entity.Models;

namespace ZedBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        //[AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLoginViewModel)
        {

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(userLoginViewModel.Email);

                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, userLoginViewModel.Password, userLoginViewModel.IsRemember, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Yanlis email ve ya sifre");

                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Yanlis email ve ya sifre");

                    return View();
                }
            }
            else
            {
                return View();
            }
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {

            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home", new { Area = "" });
        }
            
    }
}
