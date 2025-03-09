using Microsoft.EntityFrameworkCore;
using Pineapple.Genetics.domain;

namespace Pineapple.Genetics.infrastructure.EntityFramework
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public required List<User> Users { get; set; }
        public required List<RawDna> RawDnas { get; set; }
        public required List<EurogenesGlobal> EurogenesGlobals { get; set; }
        public required List<Country> Countries { get; set; }
        public required List<Area> Areas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
