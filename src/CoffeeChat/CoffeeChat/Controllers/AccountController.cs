using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeChat.Data;
using CoffeeChat.Models;
using CoffeeChat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeChat.Controllers
{
    public class AccountController : Controller
    {
        protected UserManager<AppUser> UserManager { get; }
        protected SignInManager<AppUser> SignInManager { get; }
        protected ApplicationDbContext Context { get; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel signUpViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser(signUpViewModel.Login);
                var result = await UserManager.CreateAsync(user, signUpViewModel.Password);
                if (result.Succeeded)
                {
                    await SignInManager.PasswordSignInAsync(signUpViewModel.Login, signUpViewModel.Password, true,
                        false);

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(signUpViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(loginViewModel.Login, loginViewModel.Password,
                    loginViewModel.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong email or password");
                }
            }
            return View(loginViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Manage()
        {
            return View();
        }
    }
}