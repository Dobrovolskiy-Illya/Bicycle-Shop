using Bisycles.Models;
using Bisycles.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bisycles.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Invalid login or password");
                }
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, Year = model.Year, UserName = model.Email };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                
                if (result.Succeeded)
                {
                    //await signInManager.SignInAsync(user, false);

                    User CurrentUser = await userManager.FindByNameAsync(user.UserName);
                    if (user != null)
                    {
                        List<string> roles = new List<string>();

                        if (userManager.Users.Count() == 1)
                        {
                            roles.Add("super admin");
                        }
                        else 
                        {
                            roles.Add("guest");
                        }
                        await userManager.AddToRolesAsync(CurrentUser, roles);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (EditViewModel model)
        {
            User user = await userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                user.Year = model.Year;
                await userManager.UpdateAsync(user);
            }
            return RedirectToAction("Index", "Home");
        }


        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(UserChangePasswordViewModel model)
        {
            User user = await userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                await userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
