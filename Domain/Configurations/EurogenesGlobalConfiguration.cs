using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class EurogenesGlobalConfiguration : BaseConfiguration, IEntityTypeConfiguration<EurogenesGlobal>
    {
        public void Configure(EntityTypeBuilder<EurogenesGlobal> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Coordinates)
                .IsRequired()
                .HasMaxLength(Settings.CoordinatesMaxLength);

            builder.Property(x => x.CreatedBy)
                .IsRequired()
                .HasMaxLength(CreatedByMaxLength);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedBy)
                .IsRequired()
                .HasMaxLength(UpdatedByMaxLength);

            builder.Property(x => x.UpdatedAt)
                .IsRequired();

            builder.ToTable("eurogenesGlobals_tb");
        }

        public class Settings
        {
            public const int CoordinatesMaxLength = 200;
        }
    }
}
