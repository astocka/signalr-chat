﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoffeeChat.Data;
using CoffeeChat.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace CoffeeChat.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _appDbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ApplicationDbContext appDbContext, ILogger<HomeController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task <IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.LoggedUser = user;
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUserName = user.UserName;
            }
            return View();
        }
    }
}
