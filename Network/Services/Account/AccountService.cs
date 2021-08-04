using Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Network.Account;  
using Network.DTO.Account;

namespace Network.DTO
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly HttpContext _httpContext;
        public AccountService(UserManager<User> userManager,RoleManager<Role> roleManager,SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _httpContext = httpContextAccessor.HttpContext;
        }
        //public Task AuthenticateAsync()
        //{
        //    string IpAddress = IpHelper.GetIpAddress();
        //}

        public RegisterViewModel GetRegisterViewModel()
        {
            var roles = _roleManager.Roles;
            return new RegisterViewModel { Roles = roles.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList() };
        }

        public async Task<List<SelectListItem>> GetRoleAsync()
        {
            return await _roleManager.Roles.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToListAsync();
        }


        public async Task<bool> SignInAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
                return false;
            var correctPassword = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!correctPassword)
                return false;
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role,roles?.FirstOrDefault() ?? "User"),
            };
            //  await _signInManager.SignInWithClaimsAsync(user, true, claims);
            var claimsId = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(claimsId);
            var properties = new AuthenticationProperties() { IsPersistent = true };
            await _signInManager.PasswordSignInAsync(user.UserName,model.Password,false,false);
            return true;

        }

        public async Task<IdentityResult> SignUpAsync(RegisterViewModel model)
        {
            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
                await _userManager.AddToRoleAsync(user, model.Role);

            return result;
        }


        public async Task<List<SelectListItem>> GetRolesAsync()
        {
            return await _roleManager.Roles.Select(x => new SelectListItem { Value = x.Name, Text = x.Name }).ToListAsync();
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
