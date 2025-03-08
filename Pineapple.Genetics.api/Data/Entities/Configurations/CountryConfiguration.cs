using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pineapple.Genetics.api.Data.Entities.Shared;

namespace Pineapple.Genetics.api.Data.Entities.Configurations
{
    public class CountryConfiguration : BaseConfiguration, IEntityTypeConfiguration<Country>
    {
        private const int NameMaxLength = 40;
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .HasKey(e => e.Id)
                .HasName("id");

            builder.Property(a => a.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder.HasMany(c => c.Areas)
                .WithOne(a => a.Country)
                .HasForeignKey(a => a.CountryId);

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

            builder.ToTable("country");
        }
    }
}
