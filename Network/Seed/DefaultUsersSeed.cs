using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Seed
{
    public class DefaultUsersSeed
    {
        public static async Task AddDefaultUsersAsync(UserManager<User> userManager)
        {
            if(await userManager.FindByNameAsync("Admin") == null)
            {
                var user = new User { UserName = "Babu", Email = "abubakr.nazirmadov@mail.ru", LockoutEnabled = false };
                await userManager.CreateAsync(user, "Babu-123");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
