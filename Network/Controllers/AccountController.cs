using Domain.Constants;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Account;
using Service.Account.DTO;
using Service.DTO.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(UserManager<User> userManager, IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        //[Authorize(Roles = nameof(Roles.Admin))]
        public IActionResult Register()
        {
            return View(_accountService.GetRegisterViewModel());
        }

        [HttpGet]
        //[Authorize(Roles = nameof(Roles.Admin))]
        public async Task<IActionResult> SignUp()
        {
            var model = new RegisterViewModel
            {
                Roles = await _accountService.GetRolesAsync()
            };
            return View(model);
        }

        [HttpPost]
        //[Authorize(Roles = nameof(Roles.Admin))]
        public async Task<IActionResult> SignUp(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _accountService.SignUpAsync(model);
            if (result.Succeeded)
                return RedirectToAction("SignIn", "Account");
            foreach (var resultError in result.Errors)
            {
                ModelState.AddModelError(resultError.Code, resultError.Description);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Exit()
        {
            await _accountService.SignOutAsync();
            return RedirectToAction("SignIn");
        }

        [HttpGet]
        public IActionResult SignIn() => View();
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _accountService.SignInAsync(model);
            if (model.ReturnUrl != null)
                return Redirect(model.ReturnUrl ?? "/");
            if (User.IsInRole("Admin")) 
            { 
                return Redirect("/Admin/Main/Index"); 
            }
            if (result)
                return RedirectToAction("Index","Home");
            ModelState.AddModelError("SignIn", "Login or password incorrect");
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
