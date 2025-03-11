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

            var role = new Role { Id = 1, Name = "Admin" };
            modelBuilder.Entity<Role>().HasData([
                role
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
                    RoleId = role.Id,
                    Settings = "{}"
                }
            ]);
        }
    }
}
