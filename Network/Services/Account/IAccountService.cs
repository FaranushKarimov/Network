using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Network.DTO.Account;

namespace Network.Account
{
    public interface IAccountService
    {
      //  Task AuthenticateAsync();
        RegisterViewModel GetRegisterViewModel();
        Task<List<SelectListItem>> GetRolesAsync();
        Task<bool> SignInAsync(LoginViewModel model);
        Task<IdentityResult> SignUpAsync(RegisterViewModel model);
        Task SignOutAsync();
       // Task<GenericDataResponce<string>> RegisterAsync()
    }
}
