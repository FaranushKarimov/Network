using Domain.Constants;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Network.Account;
using Network.DTO;
using Network.DTO.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IDepartmentService _departmentService;
        public AccountController(UserManager<User> userManager, IAccountService accountService,IDepartmentService departmentService)
        {
            _accountService = accountService;
            _departmentService = departmentService;
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
                Roles = await _accountService.GetRolesAsync(),
                Departments = await _departmentService.GetDepartmentList()
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
            return View("SignIn");
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
            if (result)
                return Redirect("/Admin/Main/Index");
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
