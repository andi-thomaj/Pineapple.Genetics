using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Genetics.api.Data.Entities.Configurations
{
    public class RawDnaConfiguration : IEntityTypeConfiguration<RawDna>
    {
        public void Configure(EntityTypeBuilder<RawDna> builder)
        {
        }
    }
}
