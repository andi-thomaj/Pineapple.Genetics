using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.DnaInspectionManagement.Configurations
{
    public class CountryConfiguration : BaseConfiguration, IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(Settings.NameMaxLength);

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

            builder.ToTable("countries_tb");
        }

        public class Settings
        {
            public const int NameMaxLength = 40;
        }
    }
}
