using Microsoft.AspNetCore.Identity;
using Service.Account.DTO;
using Service.DTO.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Service.Account
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
