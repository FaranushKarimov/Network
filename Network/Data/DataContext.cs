using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext( DbContextOptions options) : base(options)
        {
        }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        //public DbSet<User> Users {get;set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        }
    }
}
