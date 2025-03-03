using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Genetics.api.Data.Entities.Configurations
{
    public class EurogenesGlobalConfiguration : IEntityTypeConfiguration<EurogenesGlobal>
    {
        public const int CoordinatesMaxLength = 200;
        public void Configure(EntityTypeBuilder<EurogenesGlobal> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Coordinates)
                .IsRequired()
                .HasMaxLength(CoordinatesMaxLength);
        }
    }
}
