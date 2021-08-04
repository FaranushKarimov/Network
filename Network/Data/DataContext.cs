using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Network.Data
{
    public class DataContext : IdentityDbContext<User,Role,string>
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
            builder.Entity<Operator>().HasData(
                new Operator { Id = 1, OperatorName = "Вавилон" },
                new Operator { Id = 2, OperatorName = "Мегафон" },
                new Operator { Id = 3, OperatorName = "Tcell" }
            );
            builder.Entity<Status>().HasData(
                new Status { StatusId = 1, StatusName = "Отправлено"},
                new Status { StatusId = 2, StatusName = "Одобрено"},
                new Status { StatusId = 3, StatusName = "Отказано"}
            );
            builder.Entity<Prefix>().HasData(
                new Prefix { PrefixId = 1, PrefixNumber = 98, OperatorId = 1},
                new Prefix { PrefixId = 2, PrefixNumber = 91, OperatorId = 1},
                new Prefix { PrefixId = 3, PrefixNumber = 88, OperatorId = 2},
                new Prefix { PrefixId = 4, PrefixNumber = 90, OperatorId = 2},
                new Prefix { PrefixId = 5, PrefixNumber = 77, OperatorId = 3},
                new Prefix { PrefixId = 6, PrefixNumber = 93, OperatorId = 3}
            );
            builder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "ИТ" },
                new Department { DepartmentId = 2, DepartmentName = "Терминалы"},
                new Department { DepartmentId = 3, DepartmentName = "Логисты"},
                new Department { DepartmentId = 4, DepartmentName = "Юристы"},
                new Department { DepartmentId = 5, DepartmentName = "Отдел Партнеров"},
                new Department { DepartmentId = 6, DepartmentName = "Карточный Отдел"},
                new Department { DepartmentId = 7, DepartmentName = "Кредитный Комитет"},
                new Department { DepartmentId = 8, DepartmentName = "Бухгалтерия"},
                new Department { DepartmentId = 9, DepartmentName = "ЦДО"},
                new Department { DepartmentId = 10, DepartmentName = "Маркетинг"},
                new Department { DepartmentId = 11, DepartmentName = "МХБ"},
                new Department { DepartmentId = 12, DepartmentName = "Хадамоти аудити дохили"},
                new Department { DepartmentId = 13, DepartmentName = "Хочагидори"},
                new Department { DepartmentId = 14, DepartmentName = "Депозитный отдел"},
                new Department { DepartmentId = 15, DepartmentName = "Филиал Худжанда"},
                new Department { DepartmentId = 16, DepartmentName = "Отдел Качества"},
                new Department { DepartmentId = 17, DepartmentName = "Хадамоти Комплайнс"},
                new Department { DepartmentId = 18, DepartmentName = "Авто кредит"},
                new Department { DepartmentId = 19, DepartmentName = "Фронт"}
            );

        }
    }
}
