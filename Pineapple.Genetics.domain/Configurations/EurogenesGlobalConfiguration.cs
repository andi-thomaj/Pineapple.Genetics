using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pineapple.Genetics.domain;
using Pineapple.Genetics.domain.Shared;

namespace Pineapple.Genetics.domain.Configurations
{
    public class EurogenesGlobalConfiguration : BaseConfiguration, IEntityTypeConfiguration<EurogenesGlobal>
    {
        private const int CoordinatesMaxLength = 200;
        public void Configure(EntityTypeBuilder<EurogenesGlobal> builder)
        {
            builder
                .HasKey(e => e.Id)
                .HasName("id");

            builder.Property(e => e.Coordinates)
                .HasColumnName("coordinates")
                .IsRequired()
                .HasMaxLength(CoordinatesMaxLength);

            builder.Property(x => x.CreatedBy)
                .HasColumnName("created_by")
                .IsRequired()
                .HasMaxLength(CreatedByMaxLength);

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(x => x.UpdatedBy)
                .HasColumnName("updated_by")
                .IsRequired()
                .HasMaxLength(UpdatedByMaxLength);

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();

            builder.ToTable("eurogenes_global");
        }
    }
}
