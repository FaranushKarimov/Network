using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Network.Seed;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var context = scope.ServiceProvider.GetRequiredService<DataContext>();
            await DefaultRoleSeed.AddDefaultRoleAsync(roleManager);
            await DefaultUsersSeed.AddDefaultUsersAsync(userManager);
           await context.Database.MigrateAsync();
           await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
