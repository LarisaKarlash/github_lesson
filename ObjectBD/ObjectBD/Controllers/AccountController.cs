using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ObjectBD.Models;
using ObjectBD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.Controllers
{
    public class AccountController : Controller
    {
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly SignInManager<IdentityUser> _signInManager;

        private readonly UserManager<IdentityUserPolzow> _userManager;
        private readonly SignInManager<IdentityUserPolzow> _signInManager;

        public AccountController(UserManager<IdentityUserPolzow> userManager, 
                                 SignInManager<IdentityUserPolzow> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountRegisterViewModel registerViewModel)
        {

            if (ModelState.IsValid)
            {
                var user = new IdentityUserPolzow { FirstName = registerViewModel.FirstName, LastName = registerViewModel.LastName, UserName = registerViewModel.UserName, Email = registerViewModel.Email };
                var createTask = _userManager.CreateAsync(user, registerViewModel.Password); //принимает имя, password
                if (createTask.Result.Succeeded)
                {
                    return RedirectToAction("Index","Home"); //передает управление
                }

                foreach (var error in createTask.Result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
                
            }

            return View();
        }

        


    }
}
