using System.Reflection;
using Domain.DnaInspectionManagement;
using Domain.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public required DbSet<User> Users { get; set; }
        public required DbSet<Role> Roles { get; set; }
        public required DbSet<DnaInspection> DnaInspections { get; set; }
        public required DbSet<Country> Countries { get; set; }
        public required DbSet<Area> Areas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Domain"));

            modelBuilder.Entity<Role>().HasData([
                new Role { Id = (int)Domain.UserManagement.Roles.Admin, Name = Domain.UserManagement.Roles.Admin.ToString() },
                new Role { Id = (int)Domain.UserManagement.Roles.Basic, Name = Domain.UserManagement.Roles.Basic.ToString() }
            ]);
            modelBuilder.Entity<User>().HasData([
                new User
                {
                    Id = 1,
                    FirstName = "John",
                    MiddleName = "Doe",
                    LastName = "Smith",
                    Username = "johnsmith",
                    Email = "andi.dev94@gmail.com",
                    Password = "password",
                    RoleId = (int)Domain.UserManagement.Roles.Admin,
                    Settings = "{}"
                }
            ]);
        }
    }
}
