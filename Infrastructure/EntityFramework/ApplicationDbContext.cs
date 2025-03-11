using System.Reflection;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public required DbSet<User> Users { get; set; }
        public required DbSet<RawDna> RawDnas { get; set; }
        public required DbSet<EurogenesGlobal> EurogenesGlobals { get; set; }
        public required DbSet<Country> Countries { get; set; }
        public required DbSet<Area> Areas { get; set; }
        public required DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Domain"));

            modelBuilder.Entity<Role>().HasData([
                new Role { Id = (int)Domain.Roles.Admin, Name = Domain.Roles.Admin.ToString() },
                new Role { Id = (int)Domain.Roles.Basic, Name = Domain.Roles.Basic.ToString() }
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
                    RoleId = (int)Domain.Roles.Admin,
                    Settings = "{}"
                }
            ]);
        }
    }
}
