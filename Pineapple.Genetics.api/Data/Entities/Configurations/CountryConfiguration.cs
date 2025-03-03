using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Genetics.api.Data.Entities.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public const int NameMaxLength = 40;
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder.HasMany(c => c.Areas)
                .WithOne(a => a.Country)
                .HasForeignKey(a => a.CountryId);
        }
    }
}
