using Domain.Constants;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Seed
{
    public class DefaultRoleSeed
    {
        public static async Task AddDefaultRoleAsync(RoleManager<Role> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(Roles.Admin))
                await roleManager.CreateAsync(new Role { Name = Roles.Admin, Translate = "Админ" });
            if (!await roleManager.RoleExistsAsync(Roles.User))
                await roleManager.CreateAsync(new Role { Name = Roles.User, Translate = "Пользователь" });
        }
    }
}
