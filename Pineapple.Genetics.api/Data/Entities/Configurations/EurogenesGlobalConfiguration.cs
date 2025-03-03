using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Genetics.api.Data.Entities.Configurations
{
    public class EurogenesGlobalConfiguration : IEntityTypeConfiguration<EurogenesGlobal>
    {
        public void Configure(EntityTypeBuilder<EurogenesGlobal> builder)
        {
        }
    }
}
