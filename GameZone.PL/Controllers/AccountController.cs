using DAL.Model;
using GameZone.PL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GameZone.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager , SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
       
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var usdr = new AppUser
                {
                    FName = registerVM.FName,
                    LName = registerVM.LName,
                    Email = registerVM.Email,
                    UserName = registerVM.Email.Split('@')[0]
                }; 
                var res =await  userManager.CreateAsync(usdr , registerVM.Password);
                if (res.Succeeded)
                    return RedirectToAction("LogIn");
                foreach (var item in res.Errors)
                    ModelState.AddModelError(string.Empty, item.Description); 
               
            }
            return View(registerVM);
        }

        public IActionResult LogIn()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInVM logInVM)
        {
            if (ModelState.IsValid) 
            {
                var user  = await userManager.FindByEmailAsync(logInVM.Email); 
                if (user is null)
                {
                    ModelState.AddModelError("Email", "Invalid Email");
                    return View(logInVM); 
                }
                var res = await userManager.CheckPasswordAsync(user, logInVM.Password);
                if (!res)
                {
                    ModelState.AddModelError("password", "Invalid Password"); 
                    return View(logInVM);
                }
                var res2 = await signInManager.PasswordSignInAsync(user, logInVM.Password, false, false);
                if (res2.Succeeded)
                    return RedirectToAction("Index", "Home");
              
            }

            return View(logInVM);
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(LogIn)); 
        }
    }
}
