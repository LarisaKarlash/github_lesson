﻿using CountryZip.Models;
using CountryZip.Services;
using CountryZip.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CountryZip.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager; //Идентифицирует Userа
        private readonly SignInManager<ApplicationUser> _signInManager;  // private readonly SignInManager<ApplicationUser> _signInManager; //Логинит пользователя зарегистрированного по UserManager
        public readonly IMessageSender _messageSender;
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMessageSender messageSender
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _messageSender = messageSender;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(AccountRegisterViewModel registerViewModel)
        {

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    UserName = registerViewModel.Email,
                    Email = registerViewModel.Email
                };

                var createTask = _userManager.CreateAsync(user, registerViewModel.Password); //принимает имя, password
                if (createTask.Result.Succeeded)
                {
                    _messageSender.SendMessage(registerViewModel);
                    return RedirectToAction("Index", "Home"); //передает управление
                }

                foreach (var error in createTask.Result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(AccountLoginViewModel loginViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var signInTask = _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.SaveSession, false);

                if (signInTask.Result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    // if (loginViewModel.SaveSession)
                    {
                        return Redirect(returnUrl); //returnUrl перенаправляет на страницу на которой мы хотели перейди до логирования
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Incorrect username or password");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");

            //return View();
        }


    }
}