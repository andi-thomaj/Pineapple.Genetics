using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Genetics.api.Data.Entities.Configurations
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public const int NameMaxLength = 40;
        public void Configure(EntityTypeBuilder<Area> builder)
        { 
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);
        }
    }
}
